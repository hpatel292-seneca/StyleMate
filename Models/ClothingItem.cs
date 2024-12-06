using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Foreign key for the user who owns this item
        [BindNever]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }

}
