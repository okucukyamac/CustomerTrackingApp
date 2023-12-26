using AutoMapper;
using CustomerTracking.API.Filters;
using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Services;
using CustomerTracking.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CustomerTracking.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }


    }
}
