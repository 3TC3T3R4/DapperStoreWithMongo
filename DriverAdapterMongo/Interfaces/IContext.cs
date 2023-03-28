using DriverAdapterMongo.Enitities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAdapterMongo.Interfaces
{
    public interface IContext
    {

        public IMongoCollection<ClientEntity> Client { get; }



    }
}
