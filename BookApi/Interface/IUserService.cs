using BookApi.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Interface
{
    public interface IUserService
    {
        Task<BaseResult> Login(string username, string password);
    }
}
