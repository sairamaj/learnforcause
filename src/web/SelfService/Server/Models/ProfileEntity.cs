using Microsoft.WindowsAzure.Storage.Table;

namespace SelfService.Server.Models
{
    public class ProfileEntity : TableEntity
    {
        public string Name
        {
            get => this.RowKey;
            set
            {
                this.RowKey = value;
                this.PartitionKey = value;
            }
        }

        public string Location { get; set; }
        public string Phone { get; set; }
        public string Grade {get; set;}
        public string RegisteredClass {get; set;}
        public string GithubUrl { get; set; }
    }
}