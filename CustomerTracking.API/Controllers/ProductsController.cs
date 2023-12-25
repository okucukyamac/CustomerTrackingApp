using AutoMapper;
using CustomerTracking.API.Filters;
using CustomerTracking.Core.Models.DTOs;
using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Models.Results;
using CustomerTracking.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerTracking.API.Controllers
{
    public class ProductsController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            //return Ok(CustomResponse<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponse<List<ProductDto>>.Success(200, productsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponse<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productDtoResult = _mapper.Map<ProductDto>(product);


            return CreateActionResult(CustomResponse<ProductDto>.Success(201, productDtoResult));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponse<NoContent>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);

            return CreateActionResult(CustomResponse<NoContent>.Success(204));
        }

    }
}
