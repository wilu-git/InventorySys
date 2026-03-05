using InventorySys.Models.Database;
using InventorySys.Repository.Orders;
using InventorySys.Repository.Customers;
using InventorySys.Repository.Products;

namespace InventorySys.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        private readonly ICustomerRepository _customerRepository;
        public async Task AddOrder(Order order)
        { 
            var customer = await _customerRepository.GetCustomerById(order.CustomerId);
            if (customer.IsActive == false)
            {
                throw new Exception();
            }
            else
            { 
                await _orderRepository.AddOrder(order);
            }
        }
        public async Task DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrder(id);
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

    }
}
