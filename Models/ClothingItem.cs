using System.ComponentModel.DataAnnotations;

namespace StyleMate.Models
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public ClothingType Type { get; set; }
        [Required]
        public string? Color { get; set; }
        // Add more properties as needed
    }

}
