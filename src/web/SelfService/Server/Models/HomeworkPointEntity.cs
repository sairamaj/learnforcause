using Microsoft.WindowsAzure.Storage.Table;

namespace SelfService.Server.Models
{
    public class HomeworkPointEntity : TableEntity
    {
        public string Id {
            get => RowKey;
            set {
                this.RowKey = value;
            }
        }

        public string Description {get; set;}
        public int NumberofPoints {get; set;}
    }
}