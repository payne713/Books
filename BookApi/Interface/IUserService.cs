using BookApi.Result;
using System.Threading.Tasks;

namespace BookApi.Interface
{
    public interface IUserService
    {
        Task<DataResult> Login(string username, string password);
    }
}
