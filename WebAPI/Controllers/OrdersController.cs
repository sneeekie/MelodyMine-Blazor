using BLL.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: api/Orders
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(_orderService.GetAllOrders().ToList());
    }

    // GET: api/Orders/{id}
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _orderService.GetSingleFullOrderBy(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    
    // POST: api/Orders
    [HttpPost]
    public ActionResult<Order> CreateOrder(Order order)
    {
        _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
    }

    // PUT: api/Orders/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, Order order)
    {
        if (id != order.OrderId)
        {
            return BadRequest();
        }
        _orderService.UpdateOrderById(id, order);
        return NoContent();
    }

    // DELETE: api/Orders/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var orderToDelete = _orderService.GetSingleOrderBy(id);
        if (orderToDelete == null)
        {
            return NotFound();
        }

        _orderService.DeleteOrder(orderToDelete);
        return NoContent();
    }
}