using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/lineitems")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LineItemController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLineItems()
        {
            try
            {
                var lineItems = _service.LineItemService.GetAllLineItems(false);
                return Ok(lineItems);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLineItemById(Guid id)
        {
            try
            {
                var lineItem = _service.LineItemService.GetLineItemById(id, true);
                return Ok(lineItem);
            }
            catch
            {
                return StatusCode(500, new { Value = "Internal server error." });
            }
        }

        [HttpPost]
        public IActionResult PostLineItem([FromBody] LineItem lineItem)
        {
            try
            {
                if (lineItem == null)
                {
                    return BadRequest(new { Value = "LineItem data is null." });
                }

                _service.LineItemService.CreateLineItem(lineItem);
                return CreatedAtAction("GetLineItemById", new { id = lineItem.Id }, lineItem);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutLineItem(Guid id, [FromBody] LineItem lineItem)
        {
            try
            {
                if (lineItem == null)
                {
                    return BadRequest(new { Value = "LineItem data is null." });
                }

                var existingLineItem = _service.LineItemService.GetLineItemById(id, true);

                if (existingLineItem == null)
                {
                    return NotFound(new { Value = $"LineItem with ID {id} not found." });
                }

                _service.LineItemService.UpdateLineItem(existingLineItem);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLineItem(Guid id)
        {
            try
            {
                var existingLineItem = _service.LineItemService.GetLineItemById(id, true);

                if (existingLineItem == null)
                {
                    return NotFound(new { Value = $"LineItem with ID {id} not found." });
                }

                _service.LineItemService.DeleteLineItem(existingLineItem);
                return Ok();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Value = "Internal server error." });
            }
        }
    }
}