using CustomerTracking.Core.Models.DTOs;
using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponse<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int id);
    }
}
