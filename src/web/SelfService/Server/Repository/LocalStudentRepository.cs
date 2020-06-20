using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SelfService.Server.Models;
using SelfService.Server.Repository;
using SelfService.Shared;

namespace SelfService.Repository
{
    internal class LocalStudentRepository : IStudentRepository, IAdminRepository
    {
        private const string LocalStorage = @"c:\temp\learnbycause";
        public LocalStudentRepository()
        {
            EnsureStorage();
        }

        public async Task AddAttendance(string name, Guid classId)
        {
            var classIdFile = Path.Combine(LocalStorage, $"class_{classId}.json");
            var attendances = new List<StudentAttendance>();
            if (File.Exists(classIdFile))
            {
                attendances = JsonSerializer.Deserialize<IEnumerable<StudentAttendance>>(await File.ReadAllTextAsync(classIdFile)).ToList();
            }

            var found = attendances.FirstOrDefault(s => s.Name == name);
            if (found != null)
            {
                return;
            }

            attendances.Add(new StudentAttendance { Name = name, DateTime = DateTime.Now });
            await File.WriteAllTextAsync(classIdFile, JsonSerializer.Serialize(attendances));
        }

        public async Task<ProfileEntity> GetProfile(string email)
        {
            throw new NotImplementedException();
            // var studentFile = Path.Combine(LocalStorage, email);
            // if (!File.Exists(studentFile))
            // {
            //     return await Task.FromResult(new ProfileResource
            //     {
            //     });
            // }

            // return await Task.FromResult(JsonSerializer.Deserialize<ProfileResource>
            //         (await File.ReadAllTextAsync(studentFile)));
        }

        public async Task<StudentAttendance> GetAttendance(string name, Guid classId)
        {
            var classIdFile = Path.Combine(LocalStorage, $"class_{classId}.json");
            var attendances = new List<StudentAttendance>();
            if (File.Exists(classIdFile))
            {
                attendances = JsonSerializer.Deserialize<IEnumerable<StudentAttendance>>(await File.ReadAllTextAsync(classIdFile)).ToList();
            }

            return attendances.FirstOrDefault(s => s.Name == name);
        }

        public Task SaveProfile(ProfileEntity profile)
        {
            throw new NotImplementedException();
            // await Task.Delay(0);
            // var studentFile = Path.Combine(LocalStorage, profile.Email);
            // File.WriteAllText(studentFile, JsonSerializer.Serialize(profile, new JsonSerializerOptions
            // {
            //     WriteIndented = true,
            //     PropertyNameCaseInsensitive = true,

            // }));
        }

        public Task StartClass()
        {
            throw new NotImplementedException();
        }

        public Task StopClass()
        {
            throw new NotImplementedException();
        }

        private void EnsureStorage()
        {
            if (Directory.Exists(LocalStorage))
            {
                return;
            }

            Directory.CreateDirectory(LocalStorage);
        }
    }
}