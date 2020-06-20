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
        public IEnumerable<Student> Get()
        {
            return new List<Student>{
                new Student { Name = "sai", Age = 16, Email = "sairamaj@hotmail.com",
                Grade = "10th", Phone = "5035332071"

                },
                new Student { Name = "ram"},
                new Student { Name = "krishna"}
            };
        }

        [HttpGet]
        [Route("profile")]
        public async Task<ProfileResource> GetProfile()
        {
            return await studentRepository.Get("sairamaj@hotmail.com");
        }

        [HttpPost]
        [Route("profile")]
        public async Task SaveProfile(ProfileResource profile)
        {
            await studentRepository.Save(profile);
        }

        [HttpPost]
        [Route("class/{id}")]
        public async Task AddAttendance(Guid id)
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
        public async Task<StudentAttendance> GetClassStatus(Guid id)
        {
            this.logger.LogInformation($"GetClassStatus : {id}");
            try
            {
                // change the return tupe so that we can send not found and other proper http status codes.
                return await this.studentRepository.GetAttendance(User.GetName(), id);
            }
            catch (System.Exception e)
            {
                this.logger.LogError($"GetClassStatus : {id} : error:{e}");
                throw;
            }
        }
    }
}