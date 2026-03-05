using InventorySys.Models.Database;

namespace InventorySys.Repository.Orders
{
    public interface IOrderRepository
    {
        public Task AddOrder(Order order);
        public Task<Order?> GetOrderById(int id);
        public Task DeleteOrder(int id);
        public Task<IEnumerable<Order>> GetAllOrders();
    }
}
