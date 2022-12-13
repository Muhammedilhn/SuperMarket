using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productService.GetAllAsync();
            if(products.ResponseType == ResponseType.Success)
            {
                return Ok(products.Data);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductAddDto productAddDto)
        {
            var response = await _productService.SaveAsync(productAddDto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                return BadRequest(response.ValidationErrors);
            }
            return Ok(response.Message);
        }
    }
}
