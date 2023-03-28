using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway.Repository
{
    public  interface IProductRepository
    {

        Task<Product> InsertProductAsync(Product product);

        Task<List<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int idProduct);

        Task<Product> InsertProductSqlKataAsync(Product product);




    }
}
