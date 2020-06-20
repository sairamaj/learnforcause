using System;
using System.Threading.Tasks;
using SelfService.Models;
using SelfService.Shared;

namespace SelfService.Repository
{
    public interface IStudentRepository
    {
        Task<ProfileResource> Get(string name);
        Task Save(ProfileResource resource);
        Task AddAttendance(string name, Guid classId);
        Task<StudentAttendance> GetAttendance(string name, Guid classId);
    }
}