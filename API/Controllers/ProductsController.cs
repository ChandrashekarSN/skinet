using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo=repo;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {   
            
            return  await _repo.GetProductsAsync();           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
             return await _repo.GetProductByIDAsync(id);
        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {   
            
            return  Ok(await _repo.GetProductBrandsAsync());           
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {   
            
            return  Ok(await _repo.GetProductTypesAsync());           
        }
    }
}