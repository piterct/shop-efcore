using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum characters  is 20")]
        [MinLength(3, ErrorMessage = "Minimum characters  is 3")]
        public string Username { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum characters  is 20")]
        [MinLength(3, ErrorMessage = "Minimum characters  is 3")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
