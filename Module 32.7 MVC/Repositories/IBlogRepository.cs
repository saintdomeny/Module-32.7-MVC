using Module_32._7_MVC.Models.Db;
using System.Threading.Tasks;

namespace Module_32._7_MVC.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
