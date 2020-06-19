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
    public class ProgramController : ControllerBase
    {
        [HttpGet]
        public Task<ProgramResource> Get()
        {
            return Task.FromResult(new ProgramResource{
                CurrentInformation = System.IO.File.ReadAllText(@"c:\temp\program.md")
            });         
        }

        [HttpGet]
        [Route("class/current")]
        public async Task<CurrentRunningClassInfo> GetClassRunningStatus(){
            return await Task.FromResult(new CurrentRunningClassInfo{
                Id = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now,
                ClassName = "Java"
            });
        }
    }
}