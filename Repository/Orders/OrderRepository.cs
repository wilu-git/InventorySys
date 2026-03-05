using InventorySys.Models.Database;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repository.Orders
{
    public class OrderRepository(InventorySystemContext context) : IOrderRepository
    {
        private readonly InventorySystemContext _context = context;

        public async Task AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            await _context.Orders.ToListAsync();
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
