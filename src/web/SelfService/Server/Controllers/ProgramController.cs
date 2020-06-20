using SelfService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfService.Server.Repository;

namespace SelfService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly ILogger<ProgramController> logger;
        private readonly IAdminRepository adminReposiotry;

        public ProgramController(
            ILogger<ProgramController> logger,
            IAdminRepository adminReposiotry )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.adminReposiotry = adminReposiotry ?? throw new ArgumentNullException(nameof(adminReposiotry));
        }
        [HttpGet]
        public async Task<ProgramResource> Get()
        {
            this.logger.LogInformation("Get...");
            try
            {
                var homePageResoures = new List<HomePageResource>();
                await foreach(var resource in this.adminReposiotry.GetHomePageResources())              {
                    homePageResoures.Add(resource);
                }
                return new ProgramResource{
                    Resources = homePageResoures
                };
            }
            catch (System.Exception ex)
            {
                this.logger.LogError(ex, "Error in Get.");
                throw;
            }
        }

        [HttpGet]
        [Route("class/current")]
        public async Task<CurrentRunningClassInfo> GetClassRunningStatus(){
            return null;
            // return await Task.FromResult(new CurrentRunningClassInfo{
            //     Id = Guid.NewGuid().ToString(),
            //     DateTime = DateTime.Now,
            //     ClassName = "Java"
            // });
        }
    }
}