using System.Threading.Tasks;
using SelfService.Shared;

namespace SelfService.Repository
{
    public interface IStudentRepository
    {
        Task<ProfileResource> Get(string name);
        Task Save(ProfileResource resource);
    }
}