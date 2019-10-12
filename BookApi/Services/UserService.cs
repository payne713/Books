using BookApi.Common;
using BookApi.Interface;
using BookApi.Models;
using BookApi.Result;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class UserService : IUserService
    {

        private readonly MongodbHost mongodbHost;

        public UserService(IBookstoreDatabaseSettings settings)
        {
            mongodbHost = new MongodbHost()
            {
                Connection = settings.ConnectionString,
                DataBase = settings.DatabaseName,
                Table = "User"
            };
        }

        public async Task<BaseResult> Login(string username, string password)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Eq("UserName", username) & filterBuilder.Eq("Password", password);

            var result = new BaseResult();
            try
            {
                var list = await BaseService<User>.FindListAsync(mongodbHost, filter);
                if (list.Count > 0)
                {
                    result.Status = true;
                    result.Message = "请求成功";
                    return result;
                }
                else
                {
                    result.Status = false;
                    result.Message = "没有找到数据";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public void Add(User user)
        {

        }
    }
}
