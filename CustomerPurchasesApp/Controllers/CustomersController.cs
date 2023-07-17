using CustomerPurchasesApp.DbContex;
using CustomerPurchasesApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchasesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
       private readonly CustomerAppDbContext _customersController;
        public CustomersController(CustomerAppDbContext customerAppDbContext)
        {
            _customersController = customerAppDbContext;
        }

        //Get :api/Customers
        [HttpGet]

        public async Task<ActionResult <IEnumerable<CustomerDetail>>> GetCustomers()
        {
           
            return await _customersController.CustomerDetails.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDetail>> CreateCustomerInfo(CustomerDetail customerDetail)
        {
            //Only create new data in customer table
            //if the email is unique so that duplicate email is not inserted on customer details db.
            var checkingUniqueEmail= _customersController.CustomerDetails.
                Where(x => x.Email == customerDetail.Email).ToList();

            if(checkingUniqueEmail.Count > 0)
            {
                return BadRequest("The email is duplicated");
            }

            _customersController.CustomerDetails.Add(customerDetail);
            await _customersController.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { id = customerDetail.Customer_ID }, customerDetail);

           
            
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCustomerInfo(int id)
        {
            var customerInfo = await _customersController.CustomerDetails.FindAsync(id);
            if(customerInfo == null)
            {
                return NotFound();
            }

            _customersController.CustomerDetails.Remove(customerInfo);
            await _customersController.SaveChangesAsync();

            return NoContent();

        }

        
    }
}
