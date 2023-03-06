using System.Globalization;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class CustomersController : BaseApiController
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            return customer;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);

            return customer;
        }

        // [HttpPost("customer")]
        // public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        // {
        //     if (await EmailExists(customerDto.Email)) return BadRequest("Email already exists");

        //     TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        //     var customer = new Customer
        //     {
        //         FirstName = textInfo.ToTitleCase(customerDto.FirstName.ToLower()),
        //         LastName = textInfo.ToTitleCase(customerDto.LastName.ToLower()),
        //         Email = customerDto.Email.ToLower(),
        //         PhotoUrl = customerDto.PhotoUrl,
        //     };

        //     _context.Customers.Add(customer);
        //     await _context.SaveChangesAsync();

        //     return customer;
        // }

        // private async Task<bool> EmailExists(string email)
        // {
        //     return await _context.Customers.AnyAsync(c => c.Email == email.ToLower());
        // }
    }
}