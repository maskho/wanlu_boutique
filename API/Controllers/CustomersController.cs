using System.Globalization;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class CustomersController : BaseApiController
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return customer;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        {
            if (await EmailExists(customerDto.Email)) return BadRequest("Email already exists");

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            var customer = new Customer
            {
                FirstName = textInfo.ToTitleCase(customerDto.FirstName.ToLower()),
                LastName = textInfo.ToTitleCase(customerDto.LastName.ToLower()),
                Email = customerDto.Email.ToLower(),
                PhotoUrl = customerDto.PhotoUrl,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email.ToLower());
        }
    }
}