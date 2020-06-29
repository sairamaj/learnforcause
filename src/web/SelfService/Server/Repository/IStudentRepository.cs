using System;
using System.Threading.Tasks;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    public interface IStudentRepository
    {
        Task<ProfileEntity> GetProfile(string id);
        Task SaveProfile(ProfileEntity resource);
        Task AddAttendance(string name, string classId);
        Task<StudentAttendanceEntity> GetAttendance(string name, string classId);
    }
}