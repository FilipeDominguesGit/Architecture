using System.Collections.Generic;
using System.Linq;
using Onion.Core.Application.Extensions;
using Onion.Core.Application.Services.Products.Responses;
using Onion.Core.Domain.Repositories;

namespace Onion.Core.Application.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ServiceResponse<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = _productsRepository.GetAll();

            return new ServiceResponse<IEnumerable<ProductResponse>>()
            {
                IsSuccess = true,
                Result = products.MapToResponse()
            };

        }

        public ServiceResponse<ProductResponse> Get(int productId)
        {
            var product = _productsRepository.GetById(productId);

            if (product != null)
            {
                return new ServiceResponse<ProductResponse>()
                {
                    Result =product.MapToResponse(),
                    IsSuccess = true
                };
            }

            return new ServiceResponse<ProductResponse>();
        }
    }
}