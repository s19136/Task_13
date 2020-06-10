using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task13.Entities
{
    public class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Confectionery_Order> Confectionery_Orders { get; set; }
    }
}
