using System.ComponentModel.DataAnnotations;

namespace Models.Dtos.UserDto
{
    public class RegisterUserDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
