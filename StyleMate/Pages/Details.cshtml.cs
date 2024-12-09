using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using System.Security.Claims;

namespace StyleMate.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public DetailsModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        public ClothingItem ClothingItem { get; set; }

        public IActionResult OnGet(int id)
        {
            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve the item for the current user
            ClothingItem = _clothingService.GetItemById(id, userId);

            if (ClothingItem == null)
            {
                // Redirect to Index if the item doesn't exist or doesn't belong to the user
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
