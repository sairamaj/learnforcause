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
                var profile = await this.studentRepository.GetProfile(u.Name);
                yield return new Student
                {
                    Name = u.Name,
                    Email = u.Email,
                    GithubUrl = profile?.GithubUrl
                };
            }
        }

        [HttpGet]
        [Route("classes")]
        public async IAsyncEnumerable<ClassInfo> GetClasses()
        {
            await foreach(var entity in this.adminRepository.GetClasses("")){
                yield return new ClassInfo{
                    ClassName = entity.ClassName,
                  DateTime = entity.DateTime,
                  Id = entity.Id
                };
            }
        }
    }
}