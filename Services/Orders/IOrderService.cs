using InventorySys.Models.Database;

namespace InventorySys.Services.Orders
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task<Order?> GetOrderById(int id);
        Task DeleteOrder(int id);
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
