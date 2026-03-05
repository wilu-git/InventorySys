using InventorySys.Models.Database;
using InventorySys.Repository.Products;

namespace InventorySys.Services.Products
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task AddProduct(Product product)
        {
            await _repo.AddProduct(product);
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _repo.GetProductById(id);
        }
        public async Task DeleteProduct(int id)
        {
            await _repo.DeleteProduct(id);
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repo.GetAllProducts();
        }
    }
}
