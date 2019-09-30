using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Interface
{
    public interface IUserService
    {
        Task<bool> Login(string username, string password);
    }
}
