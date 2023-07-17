using CustomerPurchasesApp.DbContex;
using CustomerPurchasesApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchasesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly CustomerAppDbContext _OrderController;
       
        public CustomerOrderController(CustomerAppDbContext customerAppDbContext)
        {
            _OrderController = customerAppDbContext;
           
        }

        [HttpGet("{customerid}")]
        public IActionResult GetOrderDetail(int customerid)
        {
            var customerName = _OrderController.CustomerDetails
            .Where(c => c.Customer_ID == customerid)
            .Select(c => c.First_Name + " " + c.Last_Name)
            .FirstOrDefault();

            if (customerName == null)
            {
                return NotFound(); 
            }

            //using linq join to show productName and OrderId for the frontend use purpose.
            var orders = (
          from order in _OrderController.OrderDetail
          join product in _OrderController.Products on order.Product_ID equals product.Product_ID
          where order.Customer_ID == customerid
          select new
          {
              Product_Name = product.Product_Name,
              Order_ID = order.Order_ID
          }
             ).ToList();

            if (orders == null || orders.Count == 0)
            {
                var emptyOrder = new
                {
                    Customer_Name = customerName,
                    Orders = new List<object>()
                };

                return Ok(emptyOrder);
            }

            

            var viewModel = new
            {
                Customer_Name = customerName,
                Orders = orders
            };

            return Ok(viewModel);



           

        }


        //Get :api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _OrderController.Products.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<OrderDetail>> AddToCart([FromBody] AddToCartInput input)
        {
            var validCustomerId = _OrderController.CustomerDetails.Any(c => c.Customer_ID == input.CustomerId);
            var validProductId = _OrderController.Products.Any(p => p.Product_ID == input.ProductId);

            if (validProductId && validCustomerId)
            {
                var orderDetail = new OrderDetail
                {
                    Customer_ID = input.CustomerId,
                    Product_ID = input.ProductId
                };

                _OrderController.OrderDetail.Add(orderDetail);
                await _OrderController.SaveChangesAsync();
                return Ok(orderDetail);
            }

            return BadRequest();
        }

        [HttpDelete("{orderid}")]

        public async Task<ActionResult> DeleteOrderInfo(int orderid)
        {
            var OrderInfo = await _OrderController.OrderDetail.FindAsync(orderid);
            if (OrderInfo == null)
            {
                return NotFound();
            }

            _OrderController.OrderDetail.Remove(OrderInfo);
            await _OrderController.SaveChangesAsync();

            return NoContent();

        }
    }
}
