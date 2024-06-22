using Tasknew.Models;

namespace Tasknew.Services
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderDto order);
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int id);
        Task<int> DeleteOrder(int id);

        Task<OrderDto> UpdateOrder(int id, OrderDto order);
    }
}
