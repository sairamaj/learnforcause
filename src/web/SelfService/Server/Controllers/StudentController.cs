using SelfService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SelfService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
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
                Grade = "10",
                GitUrl = "http://github.com/sairamaj"
            });
        }
    }
}