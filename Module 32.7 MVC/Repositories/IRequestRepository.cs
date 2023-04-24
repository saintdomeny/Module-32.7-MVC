using Module_32._7_MVC.Models.Db;
using System.Threading.Tasks;

namespace Module_32._7_MVC.Repositories
{
    public interface IRequestRepository
    {
        Task LogRequest(string url);
        Task<LogRequest[]> GetRequests();
    }
}
