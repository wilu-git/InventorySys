using InventorySys.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repository.Products
{
    public class ProductRepository (InventorySystemContext context) : IProductRepository    
    {
        private readonly InventorySystemContext _context = context;
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }
    }
}
