using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task13.DTO
{
    public class ConfectioneryDTO
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Notes { get; set; }
    }
    public class AddOrderRequest
    {
        [Required]
        //[RegularExpression("^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)[0-9][0-9]$")]
        //mm-dd-yyyy | mm.dd.yyyy | mm/dd/yyyy format
        public DateTime DateAccepted { get; set; }
        [Required]
        [MaxLength(255)]
        public string Notes { get; set; }
        [Required]
        public List<ConfectioneryDTO> Confectionery { get; set; }
    }
}
