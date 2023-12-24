using AutoMapper;
using CustomerTracking.Core.Models.DTOs;
using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Models.Results;
using CustomerTracking.Core.Repositories;
using CustomerTracking.Core.Services;
using CustomerTracking.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int id)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(id);

            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponse<CategoryWithProductsDto>.Success(200,categoryDto);
        }
    }
}
