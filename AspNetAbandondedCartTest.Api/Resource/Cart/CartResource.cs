using AspNetAbandondedCartTest.Api.Resource.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Api.Resource.Cart
{
    public class CartResource
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int IssueDays { get; set; }
        public CustomerResource Customer { get; set; }
    }
}
