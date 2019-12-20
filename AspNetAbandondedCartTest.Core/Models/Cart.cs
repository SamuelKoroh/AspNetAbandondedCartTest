using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AspNetAbandondedCartTest.Core.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new Collection<CartItem>();
        }
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public CartState Status { get; set; }
        public ICollection<CartItem> CartItems  { get; set; }
    }
}
