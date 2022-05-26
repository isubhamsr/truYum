using System.ComponentModel.DataAnnotations;

namespace truYum.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public int Price { get; set; }

        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; } = false;
        
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = false;

        [Display(Name = "Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
