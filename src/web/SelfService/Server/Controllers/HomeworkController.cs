using SelfService.Shared;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfService.Server.Repository;
using System.Collections.Generic;

namespace SelfService.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HomeworkController : ControllerBase
    {
        private readonly ILogger<HomeworkController> logger;
        private readonly IAdminRepository adminRepository;

        public HomeworkController(
            ILogger<HomeworkController> logger,
            IGraphRepository graphRepository,
            IAdminRepository adminRepository,
            IStudentRepository studentRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }

        [HttpGet]
        public async IAsyncEnumerable<HomeworkPoint> GetHomeworkPoints()
        {
            await foreach (var entity in this.adminRepository.GetHomeworkPoints())
            {
                yield return new HomeworkPoint
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    Category = entity.Category,
                    NumberofPoints = entity.NumberofPoints,
                    NumberId = entity.NumberId,
                };
            }
        }
    }
}