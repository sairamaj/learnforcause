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
using SelfService.Server.Models;
using SelfService.Server.Repository;

namespace SelfService.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly IStudentRepository studentRepository;

        public StudentController(
            ILogger<StudentController> logger,
            IStudentRepository studentRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        [HttpGet]
        [Route("profile")]
        public async Task<ProfileResource> GetProfile()
        {
            var entity = await studentRepository.GetProfile(User.GetName());
            if (entity == null)
            {
                return new ProfileResource
                {
                    Name = User.GetName(),
                    Email = User.GetEmail()
                };
            }
            return new ProfileResource
            {
                Name = entity.Name,
                Email = User.GetEmail(),
                Location = entity.Location,
                GitUrl = entity.GithubUrl,
                Grade = entity.Grade,
                Phone = entity.Phone,
                RegisteredClass = entity.RegisteredClass
            };
        }

        [HttpPost]
        [Route("profile")]
        public async Task SaveProfile(ProfileResource profile)
        {
            await studentRepository.SaveProfile(new ProfileEntity
            {
                Name = profile.Name,
                Location = profile.Location,
                Grade = profile.Grade,
                Phone = profile.Phone,
                GithubUrl = profile.GitUrl,
                RegisteredClass = profile.RegisteredClass
            });
        }

        [HttpPost]
        [Route("class/{id}")]
        public async Task AddAttendance(string id)
        {
            try
            {
                this.logger.LogInformation($"AddAttendance : {id}: {User.GetName()}");
                await this.studentRepository.AddAttendance(User.GetName(), id);
            }
            catch (System.Exception e)
            {
                this.logger.LogError($"AddAttendance : {id} : error:{e}");

                throw;
            }
        }

        [HttpGet]
        [Route("class/{id}")]
        public async Task<StudentAttendance> GetClassStatus(string id)
        {
            this.logger.LogInformation($"GetClassStatus : {id}");
            try
            {
                // change the return tupe so that we can send not found and other proper http status codes.
                var attendance = await this.studentRepository.GetAttendance(User.GetName(), id);
                if (attendance == null)
                {
                    return null;
                }
                return new StudentAttendance
                {
                    DateTime = attendance.DateTime,
                    Name = attendance.Name,
                };
            }
            catch (System.Exception e)
            {
                this.logger.LogError($"GetClassStatus : {id} : error:{e}");
                throw;
            }
        }
    }
}