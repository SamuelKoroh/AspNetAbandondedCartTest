using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AspNetAbandondedCartTest.Core.Models
{
    public class Customer : IdentityUser
    {
        public Customer()
        {
            Cart = new Collection<Cart>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}
