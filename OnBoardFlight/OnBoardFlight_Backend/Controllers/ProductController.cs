using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        [HttpGet]
        [Route("Product/{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        [HttpPost]
        [Route("product/update")]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                if (!product.Discount && product.OldPrice != null)
                {
                    product.Price = (double)product.OldPrice;
                }
                else
                {
                    double temp = product.Price;
                    product.Price = (double)product.OldPrice;
                    product.OldPrice = temp;
                }
                _productRepo.UpdateProduct(product);
                _productRepo.SaveChanges();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}