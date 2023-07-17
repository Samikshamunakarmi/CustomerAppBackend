using CustomerPurchasesApp.DbContex;
using CustomerPurchasesApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchasesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CustomerAppDbContext _productController;
        public ProductController(CustomerAppDbContext customerAppDbContext)
        {
            _productController = customerAppDbContext;
        }

        //Get :api/Products
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _productController.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> CreateCustomerInfo(Products products)
        {
            var product = new Products()
            {
                Product_ID = products.Product_ID,
                Product_Name = products.Product_Name
            };
            _productController.Products.Add(product);
            await _productController.SaveChangesAsync();

            return Ok(products);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCustomerInfo(int id)
        {
            var productInfo = await _productController.Products.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }

            _productController.Products.Remove(productInfo);
            await _productController.SaveChangesAsync();

            return NoContent();

        }


    }
}
