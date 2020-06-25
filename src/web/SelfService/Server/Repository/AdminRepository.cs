using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Table;
using SelfService.Server.Models;
using SelfService.Shared;

namespace SelfService.Server.Repository
{
    internal class AdminRepository : CoreRepository, IAdminRepository
    {
        private readonly IWebHostEnvironment environment;

        public AdminRepository(IWebHostEnvironment environment, IOptions<ConnectionInfo> options) : base(options)
        {
            this.environment = environment ?? throw new System.ArgumentNullException(nameof(environment));
        }

        public async Task<CurrentClassInfoEntity> GetRunningClass()
        {
            var table = await GetTable("program");
            string filter = TableQuery.GenerateFilterConditionForBool("IsRunning", QueryComparisons.Equal, true);
            TableContinuationToken continuationToken = null;
            var result = await table.ExecuteQuerySegmentedAsync(new TableQuery<CurrentClassInfoEntity>()
            .Where(filter), continuationToken);
            if (result.Results != null)
            {
                return result.Results.FirstOrDefault();
            }

            return null;
        }

        public async Task<string> StartClass(string className)
        {
            var table = await GetTable("program");
            var entity = new CurrentClassInfoEntity
            {
                PartitionKey = "class",
                RowKey = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now,
                ClassName = className,
                IsRunning = true
            };

            var insertOrMergeOperation = TableOperation.Insert(entity);
            await table.ExecuteAsync(insertOrMergeOperation);
            return entity.RowKey;
        }

        public async Task StopClass(string id)
        {
            var table = await GetTable("program");
            var retrieveOperation = TableOperation.Retrieve<CurrentClassInfoEntity>("class", id);
            var result = await table.ExecuteAsync(retrieveOperation);
            var entity = result.Result as CurrentClassInfoEntity;
            if (entity == null)
            {
                throw new ArgumentException($"class {id} not found");
            }

            entity.IsRunning = false;
            var saveOperation = TableOperation.InsertOrMerge(entity);
            await table.ExecuteAsync(saveOperation);
        }

        public async IAsyncEnumerable<Resource> GetResources(string name)
        {
            var homePageResources = Path.Combine(this.environment.WebRootPath, "Resources", name);
            foreach (var file in Directory.GetFiles(homePageResources, "*.MD"))
            {
                var title = Path.GetFileNameWithoutExtension(file);
                var orderInfo = title.Split('_').First();
                title = title.Substring(orderInfo.Length + 1);
                yield return new Resource
                {
                    Order = System.Convert.ToInt32(orderInfo),
                    Title = title,
                    Info = await File.ReadAllTextAsync(file)
                };
            }
        }

        public IAsyncEnumerable<Student> GetStudents(string name)
        {
            throw new NotImplementedException();
        }
    }
}