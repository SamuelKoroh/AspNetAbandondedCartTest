using AspNetAbandondedCartTest.Api.Resource.Auth;
using AspNetAbandondedCartTest.Api.Resource.Cart;
using AspNetAbandondedCartTest.Api.Resource.Customers;
using AspNetAbandondedCartTest.Configuration.Extensions;
using AspNetAbandondedCartTest.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource to Domain mapping
            CreateMap<RegisterResource, Customer>()
                .ForMember(c=>c.UserName, opt=>opt.MapFrom(r => r.Email));

            CreateMap<Customer, CustomerResource>();
            CreateMap<Cart, CartResource>()
                .ForMember(cr=>cr.IssueDays, opt => opt.MapFrom(cr => cr.Customer.LastLoginDate.DayFromDate()));
        }
    }
}

