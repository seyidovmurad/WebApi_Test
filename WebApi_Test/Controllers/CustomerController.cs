using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.DataAccess;
using WebApi_Test.Entities;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDal _customer;
        private IProductDal _product;

        public CustomerController(ICustomerDal customer, IProductDal product)
        {
            _customer = customer;
            _product = product;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _customer.GetList();
            return Ok(result);
        }


        [HttpDelete]
        public IActionResult Delete(string customerId)
        {
            var foundCustomer = _customer.Get(c => c.CustomerID == customerId);
            if(foundCustomer != null)
            {
                try
                {
                    _customer.Delete(foundCustomer);
                    return Ok();
                }
                catch (Exception ex){ 
                    return BadRequest(ex.Message);
                }
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _customer.Add(customer);
                return Create(customer);
            }
            catch { }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _customer.Update(customer);
                return Ok(customer);
            }
            catch { }
            return BadRequest();
        }

        [HttpGet("{customerId}")]
        public IActionResult GetById(string customerId)
        {
            var foundCustomer = _customer.Get(c => c.CustomerID == customerId);
            if( foundCustomer != null)
            {
                return Ok(foundCustomer);
            }
            return NotFound();
        }

        [HttpGet("Alphabetic")] 
        public IActionResult GetAndOrderBy(bool ordreByDesc = false) //Order by customer's contact name
        {
            var result = _customer.GetCustomerOrderBy(ordreByDesc);
            return Ok(result); 
        }

        [HttpGet("Orders")]
        public IActionResult GetCustomerOrders(string customerId)
        {
            var result = _customer.GetCustomerOrdersById(customerId);
            return Ok(result);
        }
    }
}
