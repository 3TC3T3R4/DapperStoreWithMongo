using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infraestructure.DriverAdapter.Gateway;

using static Humanizer.In;

namespace Infraestructure.DriverAdapter
{
    public class SaleRepository : ISaleRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Sale";
        private readonly string tableName2 = "Product";
        private readonly string tableName3 = "Client";


        public SaleRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }



        public async Task<SaleWithProductAndClient> GetSaleByIdAsync(int idSale)
        {

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var Query = $"SELECT * FROM {tableName} WHERE id_sale_product_client = @idSale";
            var multiQuery = $"{Query}";
            using (var multi = await connection.QueryMultipleAsync(multiQuery, new { idSale }))
            
            {
                var sale = await multi.ReadFirstOrDefaultAsync<Sale>();
                if (sale == null)
                {
                    return null;
                }
                var proQuery = $"SELECT * FROM {tableName2} WHERE id_product = {sale.product_id_product}";
                var cliQuery = $"SELECT * FROM {tableName3} WHERE id_client = {sale.client_id_client}";
                var produt = await connection.QuerySingleOrDefaultAsync<Product>(proQuery);
                var clit = await connection.QuerySingleOrDefaultAsync<Client>(cliQuery);




                return new SaleWithProductAndClient
                {
                    id_sale_product_client = sale.id_sale_product_client,
                    Product = produt,
                    Client = clit,
                    way_to_pay = sale.way_to_pay,
                    date_sale = sale.date_sale

                };
            }
        }
    }
}
