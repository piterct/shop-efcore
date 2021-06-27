using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Maximum characters  is 60")]
        [MinLength(3, ErrorMessage = "Minimum characters  is 3")]
        public string Title { get; set; }
        [MaxLength(1024, ErrorMessage = "Maximum characters  is 60")]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The price must to be greater than 1")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The categoryId must to be greater than 1")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
