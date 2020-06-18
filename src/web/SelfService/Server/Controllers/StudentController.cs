using SelfService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfService.Repository;

namespace SelfService.Server.Controllers
{
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
        public Task<ProfileResource> GetProfile()
        {
            return Task.FromResult(new ProfileResource{
                Name = "sairama",
                Email = "sairamaj@hotmail.com",
                Grade = "10",
                GitUrl = "http://github.com/sairamaj"
            });
        }

        [HttpPost]
        [Route("profile")]
        public async Task SaveProfile(ProfileResource profile)
        {
            await studentRepository.Save(profile);
        }
    }
}