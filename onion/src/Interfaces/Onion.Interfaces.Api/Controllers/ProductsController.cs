using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Onion.Core.Application.Services.Products;
using Onion.Interfaces.Api.Extensions;
using Onion.Interfaces.Api.Models.Responses;

namespace Onion.Interfaces.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IProductsService _productService;

        public ProductsController(LinkGenerator linkGenerator,IProductsService productService)
        {
            _linkGenerator = linkGenerator;
            _productService = productService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var response = _productService.GetAllProducts();

            if (!response.IsSuccess) { 
                return BadRequest();
            }

            var products = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(products);

        }

        [HttpGet("{productId}")]
        public ActionResult<Product> Get(int productId)
        {
            var response = _productService.Get(productId);

            if (response.IsSuccess && response.Result == null )
            {
                return NotFound();
            }

            if (!response.IsSuccess)
            {
                return BadRequest();

            }

            var product = response.Result.MapToResponse(_linkGenerator, HttpContext);

            return Ok(product);
        }

    }
}