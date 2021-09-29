using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApplication.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        //List<Product> products = new List<Product>
        // {
        //      new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
        //      new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
        //      new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        // };
        private readonly Microsoft.Extensions.Logging.ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return Product.GetProducts();
        }
        [HttpGet("{id}", Name = nameof(GetProductById))]
        public IEnumerable<Product> GetProductById(int id)
        {
            var products = Product.GetProducts();
            var p = products.FirstOrDefault((p) => p.Id == id);

            yield return p;
        }

        [HttpPost(Name = nameof(CreateProduct))]
        public int CreateProduct(CreateProduct createProduct)
        {

            if (!ModelState.IsValid)
            {
                return 0;
            }

            return Product.AddProduct(createProduct);
        }
        [HttpDelete("{name}", Name = nameof(DeleteProduct))]
        public int DeleteProduct(string name)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            return Product.DeleteProduct(name);
        }

        [HttpPut(Name = nameof(UpdateProduct))]
        public int UpdateProduct(UpdateProduct updateproduct)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            return Product.UpdateProduct(updateproduct);
        }




    }
}