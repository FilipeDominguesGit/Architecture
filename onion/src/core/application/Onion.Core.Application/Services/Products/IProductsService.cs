using System.Collections.Generic;
using Onion.Core.Application.Services.Products.Responses;

namespace Onion.Core.Application.Services.Products
{
    public interface IProductsService
    {
        ServiceResponse<IEnumerable<ProductResponse>> GetAllProducts();
        ServiceResponse<ProductResponse> Get(int productId);
    }
}