using BookApi.Common;
using BookApi.Interface;
using BookApi.Models;
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

        public async Task<bool> Login(string username,string password)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Eq("UserName", username) & filterBuilder.Eq("Password", password);

            try
            {
                var list = await BaseService<User>.FindListAsync(mongodbHost, filter);
                if (list.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
            
            
        }

        public void Add(User user)
        {

        }
    }
}
