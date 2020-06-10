using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task13.Entities;

namespace task13.DTO
{
    public class OrdersDTO
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public List<Confectionery> confList { get; set; }
    }

    public class OrdersResponse
    {
        public List<OrdersDTO> orders { get; set; }
        public string Error { get; set; }
    }
}
