using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Repository
{
    class AzureStudentRepository : IStudentRepository
    {
        ConnectionInfo connectionInfo;
        public AzureStudentRepository(IOptions<ConnectionInfo> options)
        {
            if (options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }

            connectionInfo = options.Value;
        }

        public async Task<ProfileEntity> GetProfile(string name)
        {
            var tableClient = this.StorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("student");
            var retrieveOperation = TableOperation.Retrieve<ProfileEntity>(name, name);
            var result = await table.ExecuteAsync(retrieveOperation);
            return result.Result as ProfileEntity;
        }

        public async Task SaveProfile(ProfileEntity entity)
        {
            var tableClient = this.StorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("student");
            //table.

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

        private CloudStorageAccount StorageAccount => CloudStorageAccount.Parse(this.connectionInfo.StorageConnectionString);
    }
}