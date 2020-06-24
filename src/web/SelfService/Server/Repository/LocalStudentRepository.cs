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

        public Task AddAttendance(string name, string classId)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileEntity> GetProfile(string email)
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

        public Task<StudentAttendanceEntity> GetAttendance(string name, string classId)
        {
            throw new NotImplementedException();
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

        public Task<string> StartClass(string className)
        {
            throw new NotImplementedException();
        }

        public Task StopClass(string id)
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

        public IAsyncEnumerable<HomePageResource> GetHomePageResources()
        {
            throw new NotImplementedException();
        }

        public Task<CurrentClassInfoEntity> GetRunningClass()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Resource> GetResources(string name)
        {
            throw new NotImplementedException();
        }
    }
}