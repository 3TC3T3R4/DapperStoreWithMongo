using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDapper.TestProduct
{
    public class TestProductUseCase
    {
        [Fact]
        public async Task GetListProducts()
        {

            var productRepositorioMock = new Mock<IProductRepository>();

            productRepositorioMock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(new List<Product>());
            var productCasoDeUso = new ProductUseCase(productRepositorioMock.Object);
            var result = await productCasoDeUso.GetListProducts();
            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);

        }

        [Fact]
        public async Task AddProduct()
        {

            var productRepositorioMock = new Mock<IProductRepository>();

            productRepositorioMock.Setup(x => x.InsertProductAsync(It.IsAny<Product>())).ReturnsAsync(new Product());
            var productCasoDeUso = new ProductUseCase(productRepositorioMock.Object);
            var result = await productCasoDeUso.AddProduct(new Product());
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public async Task getProductById()
        {

            var productRepositorioMock = new Mock<IProductRepository>();

            productRepositorioMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product());
            var productCasoDeUso = new ProductUseCase(productRepositorioMock.Object);
            var result = await productCasoDeUso.GetProductById(1);
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }




    }
}
