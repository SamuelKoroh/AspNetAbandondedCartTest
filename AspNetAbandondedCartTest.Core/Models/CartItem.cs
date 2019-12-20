using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetAbandondedCartTest.Core.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
