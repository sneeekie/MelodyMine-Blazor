using Shared.DTOs;
using DataLayer.Models;

namespace BLL.Interfaces;

public interface IOrderService
{
    public void CreateOrder(Order? order);
    public void CreateOrderProductDetails(List<OrderProductDetails> orderProductDetails);
    public int CreateAddress(Address address);
    public void DeleteOrder(Order? order);
    public Order? GetSingleOrderBy(int id);
    public Order GetSingleFullOrderBy(int id);
    public Order GetSingleOrderBy(string email);
    public Order GetSingleFullOrderBy(string email);
    public void UpdateOrderById(int orderId, Order newOrder);
    public void UpdateOrderByEmail(string orderEmail, Order newOrder);
    public IQueryable<Order?> GetAllOrders();
    public IQueryable<Order> GetAllFullOrders();
    public void UpdateAddress(int addressId, Address newAddress);
    public void UpdateOrderProductDetails(List<OrderProductDetails> newOrderProductDetails);
    public bool OrderExists(int id);
    public OrderDto GetOrderDtoById(int id);
    public void UpdateOrderDto(OrderDto orderDto);
    public void UpdateOrderProductDetailsDto(List<OrderProductDetailsDto> orderProductDetailsDtos);
    public List<OrderProductDetailsDto> GetOrderProductDetailsDtoByOrderId(int orderId);
    void AddProductDetails(IEnumerable<OrderProductDetails> orderProductDetails);
}