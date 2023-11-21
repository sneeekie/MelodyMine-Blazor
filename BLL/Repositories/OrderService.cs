using Shared.DTOs;
using BLL.Interfaces;
using DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public class OrderService : IOrderService
{
    private readonly EfDbContext _context;

    public OrderService(EfDbContext melodyMineService)
    {
        _context = melodyMineService;
    }

    public void CreateOrder(Order? order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void CreateOrderProductDetails(List<OrderProductDetails> orderProductsDetails)
    {
        foreach (OrderProductDetails opd in orderProductsDetails)
        {
            _context.OrderProductDetails.Add(opd);
        }
        _context.SaveChanges();
    }

    public int CreateAddress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();

        return address.AddressId;
    }

    public void AddProductDetails(IEnumerable<OrderProductDetails> orderProductDetails)
    {
        _context.OrderProductDetails.AddRange(orderProductDetails);
        _context.SaveChanges();
    }

    public void DeleteOrder(Order? order)
    {
        var existingOrder = _context.Orders.Find(order.OrderId);
        if (existingOrder != null)
        {
            _context.Orders.Remove(existingOrder);
            _context.SaveChanges();
        }
    }

    public Order? GetSingleOrderBy(int id)
    {
        Order? tempOrder = _context.Orders
            .FirstOrDefault(o => o.OrderId == id);

        return tempOrder;
    }

    public Order GetSingleFullOrderBy(int id)
    {
        return _context.Orders
            .Include(o => o.OrderProductDetails)
            .Include(o => o.Address)
            .FirstOrDefault(o => o.OrderId == id);
    }

    public Order GetSingleOrderBy(string email)
    {
        Order tempOrder = _context.Orders
            .FirstOrDefault(o => o.Email == email);

        return tempOrder;
    }

    public Order GetSingleFullOrderBy(string email)
    {
        return _context.Orders
            .Include(o => o.OrderProductDetails)
            .Include(o => o.Address)
            .FirstOrDefault(o => o.Email == email);
    }

    public void UpdateOrderById(int orderId, Order newOrder)
    {
        Order existingOrder = _context.Orders
            .Include(o => o.OrderProductDetails)
            .Include(o => o.Address)
            .FirstOrDefault(o => o.OrderId == orderId);

        if (existingOrder == null)
        {
            throw new Exception($"Order with ID {orderId} not found.");
        }

        existingOrder.Email = newOrder.Email;
        existingOrder.BuyDate = newOrder.BuyDate;
        existingOrder.AddressId = newOrder.AddressId;

        if (newOrder.OrderProductDetails != null)
        {
            foreach (var newOpd in newOrder.OrderProductDetails)
            {
                var existingOpd = existingOrder.OrderProductDetails
                    .FirstOrDefault(opd => opd.OrderProductDetailsId == newOpd.OrderProductDetailsId);

                if (existingOpd != null)
                {
                    _context.Entry(existingOpd).CurrentValues.SetValues(newOpd);
                }
                else
                {
                    existingOrder.OrderProductDetails.Add(newOpd);
                }
            }
        }

        if (newOrder.Address != null && existingOrder.AddressId == newOrder.Address.AddressId)
        {
            _context.Entry(existingOrder.Address).CurrentValues.SetValues(newOrder.Address);
        }

        _context.SaveChanges();
    }

    public void UpdateOrderByEmail(string orderEmail, Order newOrder)
    {
        Order tempOrder = _context.Orders
            .FirstOrDefault(o => o.Email == orderEmail);

        if (tempOrder == null)
        {
            return;
        }

        tempOrder.Email = newOrder.Email;
        tempOrder.BuyDate = newOrder.BuyDate;
        _context.SaveChanges();
    }


    public IQueryable<Order?> GetAllOrders()
    {
        IQueryable<Order?> tempOrders = _context.Orders;

        return tempOrders;
    }

    public IQueryable<Order> GetAllFullOrders()
    {
        IQueryable<Order> tempOrders = _context.Orders
            .Include(o => o.OrderProductDetails);

        return tempOrders;
    }

    public void UpdateAddress(int addressId, Address newAddress)
    {
        var address = _context.Addresses.Find(addressId);
        if (address != null)
        {
            _context.Entry(address).CurrentValues.SetValues(newAddress);
            _context.SaveChanges();
        }
    }

    public void UpdateOrderProductDetails(List<OrderProductDetails> newOrderProductDetails)
    {
        foreach (var opd in newOrderProductDetails)
        {
            var existingOpd = _context.OrderProductDetails.Find(opd.OrderProductDetailsId);
            if (existingOpd != null)
            {
                _context.Entry(existingOpd).CurrentValues.SetValues(opd);
            }
        }
        _context.SaveChanges();
    }

    public bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.OrderId == id);
    }

    // DTO Services
    public void UpdateOrderDto(OrderDto orderDto)
    {
        var existingOrder = _context.Orders
            .Include(o => o.Address)
            .FirstOrDefault(o => o.OrderId == orderDto.OrderId);

        if (existingOrder == null)
            throw new Exception($"Order with ID {orderDto.OrderId} not found.");

        existingOrder.Email = orderDto.Email;
        existingOrder.BuyDate = orderDto.BuyDate;

        if (existingOrder.Address != null && orderDto.Address != null)
        {
            existingOrder.Address.Postal = orderDto.Address.Postal;
            existingOrder.Address.StreetNumber = orderDto.Address.StreetNumber;
            existingOrder.Address.City = orderDto.Address.City;
            existingOrder.Address.Country = orderDto.Address.Country;
            existingOrder.Address.Street = orderDto.Address.Street;
            existingOrder.Address.CardNumber = orderDto.Address.CardNumber;
        }

        _context.SaveChanges();
    }

    public OrderDto GetOrderDtoById(int id)
    {
        var orderWithDetails = _context.Orders
            .Where(o => o.OrderId == id)
            .Select(o => new
            {
                Order = o,
                Address = o.Address,
                OrderProductDetails = o.OrderProductDetails
            })
            .FirstOrDefault();

        if (orderWithDetails == null) return null;

        var orderDto = new OrderDto
        {
            OrderId = orderWithDetails.Order.OrderId,
            Email = orderWithDetails.Order.Email,
            BuyDate = orderWithDetails.Order.BuyDate,
            Address = new AddressDto
            {
                AddressId = orderWithDetails.Address.AddressId,
                Postal = orderWithDetails.Address.Postal,
                StreetNumber = orderWithDetails.Address.StreetNumber,
                City = orderWithDetails.Address.City,
                Country = orderWithDetails.Address.Country,
                Street = orderWithDetails.Address.Street,
                CardNumber = orderWithDetails.Address.CardNumber
            },
        };

        return orderDto;
    }

    public List<OrderProductDetailsDto> GetOrderProductDetailsDtoByOrderId(int orderId)
    {
        var orderProductDetailsList = _context.OrderProductDetails
            .Where(opd => opd.OrderId == orderId)
            .Include(opd => opd.Vinyl)
            .Select(opd => new OrderProductDetailsDto
            {
                OrderProductDetailsId = opd.OrderProductDetailsId,
                Quantity = opd.Quantity,
                VinylId = opd.VinylId
            })
            .ToList();

        return orderProductDetailsList;
    }

    public void UpdateOrderProductDetailsDto(List<OrderProductDetailsDto> orderProductDetailsDtos)
    {
        foreach (var opdDto in orderProductDetailsDtos)
        {
            var existingOpd = _context.OrderProductDetails
                .Include(opd => opd.Vinyl)
                .SingleOrDefault(opd => opd.OrderProductDetailsId == opdDto.OrderProductDetailsId);

            if (existingOpd != null)
            {
                existingOpd.Quantity = opdDto.Quantity;
                existingOpd.VinylId = opdDto.VinylId;

                _context.Entry(existingOpd).State = EntityState.Modified;
            }
        }

        _context.SaveChanges();
    }
}