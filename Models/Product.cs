using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The product title is required")]
        [MaxLength(100)]
        [DisplayName("product title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The product Description is required")]
        [MaxLength(200)]
        [DisplayName("Product description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The product Price is required")]
        [Range(1, 10000)]
        public int Price { get; set; }
    }

}
