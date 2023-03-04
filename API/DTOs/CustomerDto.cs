
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CustomerDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
    }
}