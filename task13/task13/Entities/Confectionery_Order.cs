using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task13.Entities
{
    public class Confectionery_Order
    {
        public int IdOrder { get; set; }
        public int IdConfectionery { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public Order Order { get; set; }
        public Confectionery Confectionery { get; set; }
    }
}
