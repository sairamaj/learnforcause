using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using SelfService.Shared;

namespace SelfService.Repository
{
    internal class LocalStudentRepository : IStudentRepository
    {
        private const string LocalStorage = @"c:\temp\learnbycause";
        public LocalStudentRepository()
        {
            EnsureStorage();
        }

        public async Task<ProfileResource> Get(string email)
        {
            var studentFile = Path.Combine(LocalStorage, email);
            if (!File.Exists(studentFile))
            {
                return await Task.FromResult(new ProfileResource
                {
                });
            }

            return await Task.FromResult(JsonSerializer.Deserialize<ProfileResource>
                    (await File.ReadAllTextAsync(studentFile)));
        }

        public async Task Save(ProfileResource profile)
        {
            await Task.Delay(0);
            var studentFile = Path.Combine(LocalStorage, profile.Email);
            File.WriteAllText(studentFile, JsonSerializer.Serialize(profile));
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