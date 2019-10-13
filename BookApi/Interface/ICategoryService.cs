using BookApi.Request;
using BookApi.Result;
using System.Threading.Tasks;

namespace BookApi.Interface
{
    public interface ICategoryService
    {
        Task<DataResult> GetCategories(string parentId);

        Task<BaseResult> CreateCategory(CategoryRequest categoryRequest);

        Task<BaseResult> UpdateCategory(string id, CategoryRequest categoryRequest);
    }
}
