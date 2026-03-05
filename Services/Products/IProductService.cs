using InventorySys.Models.Database;

namespace InventorySys.Services.Products
{
    public interface IProductService
    {
        public Task AddProduct(Product product);
        public Task<Product?> GetProductById(int id);
        public Task DeleteProduct(int id);
        public Task<IEnumerable<Product>> GetAllProducts();
    }
}
