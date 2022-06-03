using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreAppBL;
using StoreAppModel;

namespace StoreAppAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        //=============dependency injection=================
        private iCustomerBL _customerBL;

        public CustomerController(iCustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        //==================================================

    //Data annotation to indicate  what type of HTTP verb it is
    //this is an action of a controller
    //needs what HTTP verb it is associated with
    [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                List<Customer> listofCustomers = _customerBL.GetAllCustomer();

                //followed by "Ok()" it determines what http status code to givee
                return Ok(listofCustomers);
                
            }
            catch (SqlException)
            {
                
                return NotFound("No Customer Exists");
            }
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCusotmer([FromBody] Customer p_customer)
        {
            try
            {
                _customerBL.AddCustomer(p_customer);
                return Created("Customer was created", p_customer);
            }
            catch (SqlException)
            {
                
                return Conflict();
            }
        }

        [HttpGet("SearchCustomerbyUsername")]
        public IActionResult SearchCustomer([FromQuery] string customerusername)
        {
            try
            {
                return Ok(_customerBL.SearchCustomer(customerusername));
            }
            catch (SqlException)
            {
                
                return Conflict();
            }
        }
    }

}
