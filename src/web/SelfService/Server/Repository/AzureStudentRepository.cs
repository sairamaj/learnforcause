using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using SelfService.Models;
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

        public Task<ProfileResource> Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(ProfileResource resource)
        {
            var tableClient = this.StorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("student");
            //table.

            throw new System.NotImplementedException();
        }

        private CloudStorageAccount StorageAccount => CloudStorageAccount.Parse(this.connectionInfo.StorageConnectionString);
    }
}