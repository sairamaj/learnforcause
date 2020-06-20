using System.Threading.Tasks;

namespace SelfService.Server.Repository
{
    public interface IAdminRepository
    {
        Task StartClass();
        Task StopClass();
    }
}