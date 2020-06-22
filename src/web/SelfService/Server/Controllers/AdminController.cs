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
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController
    {
        private readonly ILogger<AdminController> logger;
        private readonly IAdminRepository adminRepository;

        public AdminController(
            ILogger<AdminController> logger,
            IAdminRepository adminRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
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
    }
}