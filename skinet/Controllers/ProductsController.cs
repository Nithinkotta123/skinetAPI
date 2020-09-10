using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
            {
            var products = await _repo.GetAllProductsAsync();

            return Ok(products);
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {

            return await _repo.GetProductAsync(id);
        }

    }
}
