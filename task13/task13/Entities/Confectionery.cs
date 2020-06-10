using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task13.Entities
{
    public class Confectionery
    {
        public int IdConfectionery { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public ICollection<Confectionery_Order> Confectionery_Orders { get; set; }
    }
}
