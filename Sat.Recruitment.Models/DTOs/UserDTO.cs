using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Models.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
