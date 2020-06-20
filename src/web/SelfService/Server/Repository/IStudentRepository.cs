using System;
using System.Threading.Tasks;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Repository
{
    public interface IStudentRepository
    {
        Task<ProfileEntity> GetProfile(string name);
        Task SaveProfile(ProfileEntity resource);
        Task AddAttendance(string name, Guid classId);
        Task<StudentAttendance> GetAttendance(string name, Guid classId);
    }
}