using InventorySys.Models.Database;

namespace InventorySys.Repository.Products
{
    public interface IProductRepository
    {
            public Task AddProduct(Product product);
            public Task<Product?> GetProductById(int id);
            public Task DeleteProduct(int id);
            public Task<IEnumerable<Product>> GetAllProducts();
    }
}
