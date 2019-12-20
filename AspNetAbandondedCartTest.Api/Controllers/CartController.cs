using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetAbandondedCartTest.Api.Resource.Cart;
using AspNetAbandondedCartTest.Configuration.Extensions;
using AspNetAbandondedCartTest.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAbandondedCartTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService _service;
        private readonly IMapper _mapper;

        public CartController(ICartService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("new-cart")]
        public async Task<IActionResult> NewCart()
        {
            var customerId = GetUserId();

            var cartExists = await _service.CheckIfCustomerIsOpen(customerId);

            if (cartExists != null)
                return Error("You still have an open cart");

            var cart = await _service.GenerateNewCart(customerId);

            return Success(cart);
        }

        [HttpGet("open-cart")]
        public async Task<IActionResult> OpenCart()
        {
            var carts = await _service.AbandonedCarts();
            var cartResource = _mapper.Map<IEnumerable<CartResource>>(carts);
            return Success(cartResource);
        }
    }

    
}