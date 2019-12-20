using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AspNetAbandondedCartTest.Core.Models
{
    public class Product
    {
        public Product()
        {
            CartItems = new Collection<CartItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ICollection<CartItem> CartItems  { get; set; }
    }
}
