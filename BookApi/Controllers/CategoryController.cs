using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Interface;
using BookApi.Request;
using BookApi.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET api/category
        [HttpGet]
        public async Task<DataResult> Get(string parentId)
        {
            return await _categoryService.GetCategories(parentId);
        }

        // POST api/category
        [HttpPost]
        public async Task<BaseResult> Post([FromBody] CategoryRequest categoryRequest)
        {
            return await _categoryService.CreateCategory(categoryRequest);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<BaseResult> Put(string id, [FromBody] CategoryRequest categoryRequest)
        {
            return await _categoryService.UpdateCategory(id, categoryRequest);
        }
    }
}