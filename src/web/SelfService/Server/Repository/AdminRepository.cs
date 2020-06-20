using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IWebHostEnvironment environment;

        public AdminRepository(IWebHostEnvironment environment)
        {
            this.environment = environment ?? throw new System.ArgumentNullException(nameof(environment));
        }

        public async IAsyncEnumerable<HomePageResource> GetHomePageResources()
        {
            var homePageResources = Path.Combine(this.environment.WebRootPath, "Resources", "HomePage");
            foreach (var file in Directory.GetFiles(homePageResources, "*.MD"))
            {
                yield return new HomePageResource
                {
                    Title = Path.GetFileNameWithoutExtension(file),
                    Info = await File.ReadAllTextAsync(file)
                };

            }
        }
        public Task StartClass()
        {
            throw new System.NotImplementedException();
        }

        public Task StopClass()
        {
            throw new System.NotImplementedException();
        }
    }
}