using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetAbandondedCartTest.Api.Resource.Auth;
using AspNetAbandondedCartTest.Core.Models;
using AspNetAbandondedCartTest.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAbandondedCartTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource)
        {
            var exists = await _authService.FindCustomerByEmailAsync(resource.Email);

            if (exists != null) return Error("This user already exists");

            var newCustomer = _mapper.Map<Customer>(resource);
            newCustomer.LastLoginDate = DateTime.Now;

            var customer = await _authService.RegisterAsync(newCustomer, resource.Password);
            
            if(!customer.Succeeded) return Errors(customer.Errors);

            return Success("The user has been created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource, [FromQuery] string cartId)
        {
            var customer = await _authService.FindCustomerByEmailAsync(resource.Email);

            if (customer == null) return Error("This user account does exists");

            var isPasswordValid = await _authService.VerifyCustomerPasswordAsync(customer, resource.Password);

            if(!isPasswordValid) return Error("This user account does exists");

            await _authService.UpdateLastLoginDate(customer);

            var token = _authService.GetUserToken(customer);

            return Ok(new { token, cartId});
        }
    }
}