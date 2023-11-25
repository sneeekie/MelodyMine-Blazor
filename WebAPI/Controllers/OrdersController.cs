using BLL.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shared.DTOs;

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
    public ActionResult<List<Order>> GetOrders()
    {
        return Ok(_orderService.GetAllOrders().ToList());
    }

    // GET: api/Orders/{id}
    [HttpGet("{id}")]
    public ActionResult<OrderDto> GetOrder(int id)
    {
        var order = _orderService.GetSingleFullOrderBy(id);
        if (order == null)
        {
            return NotFound();
        }

        var orderDto = _orderService.MapOrderToOrderDto(order);

        return Ok(orderDto);
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
    public IActionResult UpdateOrder(int id, OrderDto orderDto)
    {
        var order = _orderService.GetSingleFullOrderBy(id);
        if (order == null)
        {
            return NotFound();
        }

        if (id != orderDto.OrderId)
        {
            return BadRequest();
        }

        order.Email = orderDto.Email;
        order.BuyDate = orderDto.BuyDate;

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