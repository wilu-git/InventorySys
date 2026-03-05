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

        public async Task ReduceStock(int productId, int quantity)
        {
            var product = await _repo.GetProductById(productId);
            if (product == null)
                throw new Exception("Product not found");
            if (product.Stock < quantity)
                throw new Exception("Insufficient stock");
            product.Stock -= quantity;
            await _repo.AddProduct(product); // Assuming AddProduct updates if the product already exists
        }
    }
}
