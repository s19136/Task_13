using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task13.Entities
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
