using InventorySys.Repository.Customers;
using FluentAssertions;
using Moq;
using Xunit;
using InventorySys.Services.Customers;


namespace InventorySysTest
{
    public class CustomerTest
    {
        private readonly Mock<ICustomerRepository> _repo;
        private readonly CustomerService _customerService;

        public CustomerTest(ICustomerRepository customerRepository)
        {
            _repo = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_repo.Object);
        }

        [Fact]
        public async Task CustomerIsActive_ReturnsFalse_WhenCustomerIsNotActive()
        {
            // Arrange
            int customerId = 2;
            _repo.Setup(r => r.CustomerIsActive(customerId)).ReturnsAsync(false);
            // Act
            var result = await _customerService.CustomerIsActive(customerId);
            // Assert
            result.Should().BeFalse();
        }
        
    }
}
