using InventorySys.Models.Database;
using InventorySys.Repository.Orders;
using InventorySys.Repository.Customers;
using InventorySys.Services.Orders;
using Moq;
using Xunit;

namespace InventorySysTest
{
    public class OrderTest
    {
        private readonly Mock<IOrderRepository> _orderRepo;
        private readonly Mock<ICustomerRepository> _customerRepo;
        private readonly OrderService _orderService;

        public OrderTest()
        {

            _orderRepo = new Mock<IOrderRepository>();
            _customerRepo = new Mock<ICustomerRepository>();
            _orderService = new OrderService(_orderRepo.Object);
        }

        [Fact]
        //Customer must be active before ordering.
        public async Task AddOrder_ShouldThrowException_WhenCustomerIsNotActive()
        {
            _customerRepo.Setup(r => r.GetCustomerById(It.IsAny<int>()))
                .ReturnsAsync(new Customer { IsActive = false });

            var order = new Order { CustomerId = 1 };
        }
        public async Task AddOrder_ShouldThrowException_WhenProductStock0()
        {
             _customerRepo.Setup(r => r.GetCustomerById(It.IsAny<int>()))
                .ReturnsAsync(new Customer { IsActive = true });
            var order = new Order { CustomerId = 1, ProductId = 1, Amount = 1 };

        }
    }
}
