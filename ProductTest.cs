using InventorySys.Repository.Products;
using InventorySys.Services.Products;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InventorySysTest
{
    public class ProductTest
    {
        private readonly Mock<IProductRepository> _productRepo;
        private readonly ProductService _productService;   

        public ProductTest()
        {
                _productRepo = new Mock<IProductRepository>();
                _productService = new ProductService(_productRepo.Object);
        }

        [Fact]
        public async Task ProductStock_MustBeReduced_AfterSuccessfulOrder()
        {
                int productId = 1;
                int initialStock = 10;
                int orderQuantity = 2;
    
                _productRepo.Setup(r => r.GetProductById(productId))
                    .ReturnsAsync(new InventorySys.Models.Database.Product { ProductId = productId, Stock = initialStock });

                await _productService.ReduceStock(productId, orderQuantity);

                _productRepo.Verify(r => r.GetProductById(productId), Times.Once);
        }



    }
}
