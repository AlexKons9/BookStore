using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrderController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = _service.OrderService.GetAllOrders(false);
                return Ok(orders);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            try
            {
                var order = _service.OrderService.GetOrderById(id, true);
                return Ok(order);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest(new { Value = "Order data is null." });
                }

                _service.OrderService.CreateOrder(order);
                return CreatedAtAction("GetOrderById", new { id = order.Id }, order);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(Guid id, [FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest(new { Value = "Order data is null." });
                }

                var existingOrder = _service.OrderService.GetOrderById(id, true);

                if (existingOrder == null)
                {
                    return NotFound(new { Value = $"Order with ID {id} not found." });
                }

                _service.OrderService.UpdateOrder(existingOrder);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                var existingOrder = _service.OrderService.GetOrderById(id, true);

                if (existingOrder == null)
                {
                    return NotFound(new { Value = $"Order with ID {id} not found." });
                }

                _service.OrderService.DeleteOrder(existingOrder);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }
    }
}