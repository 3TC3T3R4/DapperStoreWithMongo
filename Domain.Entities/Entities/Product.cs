using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public  class Product
    {

        public int id_product { get; set; }
        public string name { get; set; }

        public int batch { get; set; }

        public int quantity { get; set; }
        


    }
}
