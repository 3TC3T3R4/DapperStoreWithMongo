using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Commands
{
    public class InsertNewClient
    {

        public int id_client{ get; set; }
        public int id_number { get; set; }
        public string type_id { get; set; }
        public string name { get; set; }




    }
}
