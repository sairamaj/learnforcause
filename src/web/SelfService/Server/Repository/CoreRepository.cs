using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SelfService.Server.Models;

namespace SelfService.Server.Repository
{
    class CoreRepository
    {
        ConnectionInfo connectionInfo;

        public CoreRepository(IOptions<ConnectionInfo> options)
        {
            if (options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }

            connectionInfo = options.Value;
        }

        protected CloudStorageAccount StorageAccount => CloudStorageAccount.Parse(this.connectionInfo.StorageConnectionString);

        protected async Task<CloudTable> GetTable(string name)
        {
            var tableClient = this.StorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(name);
            //table.

            await table.CreateIfNotExistsAsync();
            return table;
        }
    }
}