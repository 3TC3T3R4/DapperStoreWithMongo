using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverAdapterMongo.Enitities
{
   public class ClientEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE    
        public string Id_Mongo { get; set; }
        public int id_client { get; set; }
        public int id_number { get; set; }
        public string type_id { get; set; }
        public string name { get; set; }
        public bool state { get; set; }
    }
}
