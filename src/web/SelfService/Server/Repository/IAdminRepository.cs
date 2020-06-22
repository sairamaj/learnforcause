using System.Collections.Generic;
using System.Threading.Tasks;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    public interface IAdminRepository
    {
        Task<string> StartClass(string className);
        Task StopClass(string id);
        Task<CurrentClassInfoEntity> GetRunningClass();

        IAsyncEnumerable<HomePageResource> GetHomePageResources();
    }
}