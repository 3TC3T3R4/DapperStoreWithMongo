using Infraestructure.DriverAdapter.Gateway;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DriverAdapter
{
   public class DbConnectionBuilder : IDbConnectionBuilder
    {
        private readonly string _connectionString;

        public DbConnectionBuilder(string connectionString) =>

            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));


        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
