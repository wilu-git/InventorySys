using InventorySys.Models.Database;

namespace InventorySys.Services.Customers
{
    public interface ICustomerService
    {
        public Task AddCustomer (Customer customer);
        public Task<Customer> GetCustomerById(int id);
        public Task<bool?> CustomerIsActive(int id);
        public Task DeleteCustomer(int id);
        public Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
