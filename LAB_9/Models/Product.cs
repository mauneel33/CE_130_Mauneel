using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10_Authent.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string details { get; set; }
        public string price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
