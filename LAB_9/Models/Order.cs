using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10_Authent.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int amount { get; set; }
        public DateTime Order_date { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
