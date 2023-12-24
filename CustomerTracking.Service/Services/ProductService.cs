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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductReporsitory _productReporsitory;
        private readonly IMapper _mapper;


        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductReporsitory productReporsitory, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _productReporsitory = productReporsitory;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productReporsitory.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponse<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
