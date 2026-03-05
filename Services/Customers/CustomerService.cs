using InventorySys.Models.Database;
using InventorySys.Repository.Customers;

namespace InventorySys.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCustomer(Customer customer)
        {
            await _repo.AddCustomer(customer);
        }

        public async Task<bool?> CustomerIsActive(int id)
        {
            return await _repo.CustomerIsActive(id);
        }

        public Task DeleteCustomer(int id)
        {
            return _repo.DeleteCustomer(id);
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
