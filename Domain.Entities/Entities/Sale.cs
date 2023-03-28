using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Sale
    {

        public int id_sale_product_client { get; set; }
        public int product_id_product { get; set; }
       
        public int client_id_client { get; set; }
       
        public string way_to_pay { get; set; }

        public  DateTime date_sale { get; set; }





    }
}
