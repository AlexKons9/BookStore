using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CustomerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _service.CustomerService.GetAllCustomers(false);
                return Ok(customers);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                var customer = _service.CustomerService.GetCustomerById(id, true);
                return Ok(customer);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest(new { Value = "Customer data is null." });
                }

                _service.CustomerService.CreateCustomer(customer);
                return CreatedAtAction("GetCustomerById", new { id = customer.Id }, customer);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(Guid id, [FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest(new { Value = "Customer data is null." });
                }

                var existingCustomer = _service.CustomerService.GetCustomerById(id, true);

                if (existingCustomer == null)
                {
                    return NotFound(new { Value = $"Customer with ID {id} not found." });
                }

                _service.CustomerService.UpdateCustomer(existingCustomer);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                var existingCustomer = _service.CustomerService.GetCustomerById(id, true);

                if (existingCustomer == null)
                {
                    return NotFound(new { Value = $"Customer with ID {id} not found." });
                }

                _service.CustomerService.DeleteCustomer(existingCustomer);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }
    }
}