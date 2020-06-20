using System.Collections.Generic;
using System.Threading.Tasks;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    public interface IAdminRepository
    {
        Task StartClass();
        Task StopClass();

        IAsyncEnumerable<HomePageResource> GetHomePageResources();
    }
}