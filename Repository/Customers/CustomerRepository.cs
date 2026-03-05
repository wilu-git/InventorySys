using InventorySys.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace InventorySys.Repository.Customers
{
    public class CustomerRepository(InventorySystemContext context): ICustomerRepository
    {
        private readonly InventorySystemContext _context = context;

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> CustomerIsActive(int id)
        {
            var customer = await _context.Customers.Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();
            return customer?.IsActive;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.Where(c => c.CustomerId == id)
                .FirstOrDefaultAsync();
        }
    }
}
