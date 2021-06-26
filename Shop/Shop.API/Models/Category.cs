using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Maximum characters  is 60")]
        [MinLength(3, ErrorMessage = "Minimum characters  is 3")]
        public string Title { get; set; }
    }
}
