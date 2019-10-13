using BookApi.Common;
using BookApi.Interface;
using BookApi.Models;
using BookApi.Request;
using BookApi.Result;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MongodbHost mongodbHost;

        public CategoryService(IBookstoreDatabaseSettings settings)
        {
            mongodbHost = new MongodbHost()
            {
                Connection = settings.ConnectionString,
                DataBase = settings.DatabaseName,
                Table = "Category"
            };
        }

        public async Task<DataResult> GetCategories(string parentId)
        {
            var filterBuilder = Builders<Category>.Filter;
            FilterDefinition<Category> filter = filterBuilder.Eq("ParentId", parentId);
            var result = new DataResult();
            try
            {
                var list = await BaseService<Category>.FindListAsync(mongodbHost, filter);
                if (list.Count > 0)
                {
                    result.Status = true;
                    result.Message = "请求成功";
                    result.Data = list;
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

        public async Task<BaseResult> CreateCategory(CategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                ParentId = categoryRequest.ParentId,
                V = 0
            };
            var baseResult = new BaseResult();
            try
            {
                var result = await BaseService<Category>.AddAsync(mongodbHost, category);
                baseResult.Status = result;
                baseResult.Message = "添加成功";
                
            }
            catch (Exception ex)
            {
                baseResult.Status = false;
                baseResult.Message = ex.Message;
            }
            return baseResult;
        }

        public async Task<BaseResult> UpdateCategory(string id, CategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                ParentId = categoryRequest.ParentId,
                V = 0
            };
            var baseResult = new BaseResult();
            try
            {
                var result = await BaseService<Category>.UpdateAsync(mongodbHost, category,id);
                baseResult.Status = true;
                baseResult.Message = "更新成功";

            }
            catch (Exception ex)
            {
                baseResult.Status = false;
                baseResult.Message = ex.Message;
            }
            return baseResult;
        }
    }
}
