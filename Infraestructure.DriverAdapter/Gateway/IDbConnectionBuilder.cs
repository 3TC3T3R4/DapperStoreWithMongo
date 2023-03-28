

using System.Data;

namespace Infraestructure.DriverAdapter.Gateway
{
    public interface IDbConnectionBuilder
    {


        Task<IDbConnection> CreateConnectionAsync();



    }
}
