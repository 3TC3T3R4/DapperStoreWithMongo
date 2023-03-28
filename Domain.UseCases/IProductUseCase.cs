using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
   public  interface IProductUseCase
    {

        Task<Product> AddProduct(Product product);

        Task<List<Product>> GetListProducts();

        Task<Product> GetProductById(int id);

        Task<Product> InsertProductConKata(Product product);






    }
}
