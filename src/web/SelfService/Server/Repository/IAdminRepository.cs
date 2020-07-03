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
        Task RemoveHomeWorkPoint(string id);
        IAsyncEnumerable<HomeworkPointEntity> GetHomeworkPoints();
        Task AddStudentHomeworkPoints(string studentId, IEnumerable<string> homeworkIds);
        Task<IEnumerable<string>> GetStudentHomeworkPoints(string studentId);
        Task<ProfileEntity> GetProfile(string id);
    }
}