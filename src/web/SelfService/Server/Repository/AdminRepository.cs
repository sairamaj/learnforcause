using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Table;
using SelfService.Server.Exceptions;
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

        public async IAsyncEnumerable<ClassInfoEntity> GetClasses(string name)
        {
            var table = await GetTable("program");
            TableContinuationToken continuationToken = null;
            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(new TableQuery<ClassInfoEntity>(), continuationToken);
                foreach (var result in queryResult)
                {
                    yield return result;
                }

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
        }

        public async Task<string> AddHomeWorkPoint(string description, int numberofPoints)
        {
            var table = await GetTable("program");
            var entity = new HomeworkPointEntity
            {
                PartitionKey = "homeworkpoint",
                RowKey = Guid.NewGuid().ToString(),
                Description = description,
                NumberofPoints = numberofPoints
            };

            var insertOrMergeOperation = TableOperation.Insert(entity);
            await table.ExecuteAsync(insertOrMergeOperation);
            return entity.RowKey;
        }

        public async Task RemoveHomeWorkPoint(string id)
        {
            var table = await GetTable("program");
            var operation = TableOperation.Retrieve<HomeworkPointEntity>("homeworkpoint", id);
            var result = await table.ExecuteAsync(operation);
            if (result == null)
            {
                throw new NotFoundException();
            }

            operation = TableOperation.Delete(result.Result as HomeworkPointEntity);
            await table.ExecuteAsync(operation);

        }

        public async IAsyncEnumerable<HomeworkPointEntity> GetHomeworkPoints()
        {
            var table = await GetTable("program");
            TableContinuationToken continuationToken = null;
            string filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "homeworkpoint");

            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(
                    new TableQuery<HomeworkPointEntity>().Where(filter),
                continuationToken);
                foreach (var result in queryResult)
                {
                    yield return result;
                }

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
        }

        public async Task AddStudentHomeworkPoints(string studentId, IEnumerable<string> homeworkIds)
        {
            var table = await GetTable("student");
            var entity = new StudentHomeworkPointEntity
            {
                PartitionKey = "studenthomework",
                StudentId = studentId,
                HomeworkPointIds = JsonSerializer.Serialize(homeworkIds)
            };

            var insertOrMergeOperation = TableOperation.InsertOrReplace(entity);
            await table.ExecuteAsync(insertOrMergeOperation);
        }

        public async Task<IEnumerable<string>> GetStudentHomeworkPoints(string studentId)
        {
            var table = await GetTable("student");
            TableContinuationToken continuationToken = null;
            var filter = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "studenthomework"),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, studentId.ToString()));

            var result = await table.ExecuteQuerySegmentedAsync(new TableQuery<StudentHomeworkPointEntity>()
            .Where(filter), continuationToken);
            if (result.Results != null && result.Results.FirstOrDefault() != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<string>>(result.Results.FirstOrDefault().HomeworkPointIds);
            }

            return new List<string>();
        }

        public async Task<ProfileEntity> GetProfile(string id)
        {
            var table = await GetTable("student");
            var retrieveOperation = TableOperation.Retrieve<ProfileEntity>("student", id);
            var result = await table.ExecuteAsync(retrieveOperation);
            return result.Result as ProfileEntity;
        }

        public async IAsyncEnumerable<string> GetClassAttendance(string classId)
        {
            System.Console.WriteLine("_________________________");
            System.Console.WriteLine($"{classId}");
            System.Console.WriteLine("_________________________");
             var table = await GetTable("student");
            TableContinuationToken continuationToken = null;
            string filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, classId);
            do
            {
                var queryResult = await table.ExecuteQuerySegmentedAsync(new TableQuery().Where(filter), continuationToken);
                foreach (var result in queryResult)
                {
                    yield return result.RowKey;
                }

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);

       }
    }
}