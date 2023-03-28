using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.InsertProductAsync(product);
        }

        public async Task<Product> InsertProductConKata(Product product)
        {
            return await _productRepository.InsertProductAsync(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<List<Product>> GetListProducts()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        //Task<List<Product>> GetAllProductAsync();

        //Task<Product> GetProductByIdAsync(int idProduct);

        //Task<Product> InsertProductSqlKataAsync(Product product);
        //Task<Product> InsertProductAsync(Product product);




    }
}
