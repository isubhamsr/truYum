using System.ComponentModel.DataAnnotations;

namespace truYum.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Price { get; set; }

        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; } = false;
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
