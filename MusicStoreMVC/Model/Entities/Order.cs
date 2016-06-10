using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UserName { get; set; }
        public decimal PriceDecimal  { get; set; }
        public string Status { get; set; }
    }
}
