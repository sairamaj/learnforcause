using System.Collections.Generic;
using System.Threading.Tasks;
using SelfService.Server.Models;

namespace SelfService.Server.Repository
{
    public interface IGraphRepository
    {
        IAsyncEnumerable<GraphUser> GetUsers();
    }
}