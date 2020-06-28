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
        IAsyncEnumerable<Resource> GetResources(string name);
        IAsyncEnumerable<Student> GetStudents(string name);
        IAsyncEnumerable<ClassInfoEntity> GetClasses(string name);
        Task<string> AddHomeWorkPoint(string description, int numberofPoints);
        IAsyncEnumerable<HomeworkPointEntity> GetHomeworkPoints(string name);

    }
}