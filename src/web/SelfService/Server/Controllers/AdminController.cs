using SelfService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfService.Repository;
using SelfService.Server.Extensions;
using SelfService.Server.Repository;

namespace SelfService.Server.Controllers
{
    [Authorize(Roles = "Administrators")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController
    {
        private readonly ILogger<AdminController> logger;
        private readonly IGraphRepository graphRepository;
        private readonly IAdminRepository adminRepository;
        private readonly IStudentRepository studentRepository;

        public AdminController(
            ILogger<AdminController> logger,
            IGraphRepository graphRepository,
            IAdminRepository adminRepository,
            IStudentRepository studentRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.graphRepository = graphRepository ?? throw new ArgumentNullException(nameof(graphRepository));
            this.adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        [HttpPost]
        [Route("class/start/{name}")]
        public async Task<string> StartClass(string name)
        {
            this.logger.LogDebug($"StartClass: {name}");
            try
            {
                return await this.adminRepository.StartClass(name);
            }
            catch (System.Exception ex)
            {
                this.logger.LogError(ex, $"Error in StartClass");
                throw;
            }
        }

        [HttpPost]
        [Route("class/stop/{id}")]
        public async Task StopClass(string id)
        {
            this.logger.LogDebug($"StopClass: {id}");
            try
            {
                await this.adminRepository.StopClass(id);
            }
            catch (System.Exception ex)
            {
                this.logger.LogError(ex, $"Error in StopClass");
                throw;
            }
        }

        [HttpGet]
        [Route("students")]
        public async IAsyncEnumerable<Student> GetStudents()
        {
            await foreach (var u in this.graphRepository.GetUsers())
            {
                var profile = await this.studentRepository.GetProfile(u.Id);
                var student = new Student
                {
                    Id = u.Id,
                    Name = u.Name,
                    Profile = new ProfileResource()
                };
                if (profile != null)
                {
                    student.Profile = new ProfileResource
                    {
                        Id = profile.Id,
                        Name = profile.Name,
                        Location = profile.Location,
                        GitUrl = profile.GithubUrl,
                        Grade = profile.Grade,
                        Phone = profile.Phone,
                        RegisteredClass = profile.RegisteredClass,
                        HomeworkPoints = profile.HomeworkPoints
                    };
                }
                yield return student;
            }
        }

        [HttpGet]
        [Route("classes")]
        public async IAsyncEnumerable<ClassInfo> GetClasses()
        {
            await foreach (var entity in this.adminRepository.GetClasses(""))
            {
                yield return new ClassInfo
                {
                    ClassName = entity.ClassName,
                    DateTime = entity.DateTime,
                    Id = entity.Id
                };
            }
        }

        [HttpPost]
        [Route("homeworkpoints/{description}/{numberOfPoints:int}")]
        public async Task AddHomeworkPoint(string description, int numberOfPoints)
        {
            this.logger.LogDebug($"AddHomeworkPoint: {description} {numberOfPoints}");
            try
            {
                await this.adminRepository.AddHomeWorkPoint(description, numberOfPoints);
            }
            catch (System.Exception ex)
            {
                this.logger.LogError(ex, $"Error AddHomeworkPoint");
                throw;
            }
        }

        [HttpGet]
        [Route("homeworkpoints")]
        public async IAsyncEnumerable<HomeworkPoint> GetHomeworkPoints(string description, int numberOfPoints)
        {
            await foreach (var entity in this.adminRepository.GetHomeworkPoints())
            {
                yield return new HomeworkPoint
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    NumberofPoints = entity.NumberofPoints
                };
            }
        }

        [HttpGet]
        [Route("student/homeworkpoints/{studentId}")]
        public async Task<IEnumerable<string>> GetStudentHomeworkPoints(string studentId)
        {
            return await this.adminRepository.GetStudentHomeworkPoints(studentId);
        }

        [HttpPost]
        [Route("student/homeworkpoints/{studentId}")]
        public async Task AddStudentHomeworkPoints(
            [FromRoute] string studentId,
            IEnumerable<string> homeworkIds)
        {
            await this.adminRepository.AddStudentHomeworkPoints(studentId, homeworkIds);
            // Update homework points

            var profile = await this.studentRepository.GetProfile(studentId);
            if (profile == null)
            {
                profile = new Models.ProfileEntity();
                profile.Id = studentId;
            }

            var selectedHomeworks = this.adminRepository.GetHomeworkPoints().Where(hw => homeworkIds.Contains(hw.Id));
            profile.HomeworkPoints = await selectedHomeworks.SumAsync(s => s.NumberofPoints);
            System.Console.WriteLine($" >> {profile.Id} {profile.HomeworkPoints}<< ");
            await this.studentRepository.SaveProfile(profile);
        }
    }
}