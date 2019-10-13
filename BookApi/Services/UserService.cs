using BookApi.Common;
using BookApi.Interface;
using BookApi.Models;
using BookApi.Result;
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

        public async Task<DataResult> Login(string username, string password)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Eq("UserName", username) & filterBuilder.Eq("Password", password);

            var result = new DataResult();
            try
            {
                var list = await BaseService<User>.FindListAsync(mongodbHost, filter);
                if (list.Count > 0)
                {
                    result.Status = true;
                    result.Message = "请求成功";
                    result.Data = list[0];
                    return result;
                }
                else
                {
                    result.Status = false;
                    result.Message = "没有找到数据";
                    result.Data = "";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Data = "";
                return result;
            }
        }

        public void Add(User user)
        {

        }
    }
}
