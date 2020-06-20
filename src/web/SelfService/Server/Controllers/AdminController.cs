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
    public class AdminController
    {
        [HttpPost]
        [Route("class/start")]
        public async Task StartClass()
        {
            await Task.Delay(0);
        }

        [HttpPost]
        [Route("class/start")]
        public async Task StopClass()
        {
            await Task.Delay(0);
        }        
    }
}