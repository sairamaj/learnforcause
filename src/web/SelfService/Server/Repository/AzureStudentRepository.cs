using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Table;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    class AzureStudentRepository : CoreRepository, IStudentRepository
    {
        public AzureStudentRepository(IOptions<ConnectionInfo> options) : base(options)
        {
        }

        public async Task<ProfileEntity> GetProfile(string name)
        {
            var table =  await GetTable("student");
            var retrieveOperation = TableOperation.Retrieve<ProfileEntity>(name, name);
            var result = await table.ExecuteAsync(retrieveOperation);
            return result.Result as ProfileEntity;
        }

        public async Task SaveProfile(ProfileEntity entity)
        {
            var table =  await GetTable("student");
            await table.CreateIfNotExistsAsync();
            var insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
            await table.ExecuteAsync(insertOrMergeOperation);
        }

        public Task AddAttendance(string name, Guid classId)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAttendance> GetAttendance(string name, Guid classId)
        {
            return Task.FromResult<StudentAttendance>(null);
        }
    }
}