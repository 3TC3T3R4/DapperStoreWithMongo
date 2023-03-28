using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infraestructure.DriverAdapter.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DriverAdapter
{
    public  class ProductRepository : IProductRepository
    {


        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Product";

        public ProductRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Product>(sqlQuery);
            connection.Close();
            return result.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int idProduct)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName} WHERE id_product = {idProduct}";
            var result = await connection.QueryFirstAsync<Product>(sqlQuery);
            connection.Close();
            return result;
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var productAAgregar = new
            {
                id = product.id_product,
                nombre = product.name,
                lote = product.batch,
                cantidad = product.quantity
            };
            string sqlQuery = $"INSERT INTO {tableName} (id_product, name,batch,quantity)VALUES(@id, @nombre, @lote, @cantidad)";
            var rows = await connection.ExecuteAsync(sqlQuery,productAAgregar);
            return product;
        }

        public Task<Product> InsertProductSqlKataAsync(Product product)
        {
            throw new NotImplementedException();
        }



    }
}
