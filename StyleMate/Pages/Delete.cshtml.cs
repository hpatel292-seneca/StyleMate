using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using System.Security.Claims;

namespace StyleMate.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public DeleteModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPost(int id)
        {
            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check that the item belongs to the current user before deleting
            var existingItem = _clothingService.GetItemById(id, userId);

            if (existingItem == null)
            {
                // Redirect to Index if the item doesn't exist or doesn't belong to the user
                return RedirectToPage("./Index");
            }

            // Delete the item associated with the current user
            await _clothingService.DeleteItemAsync(id, User);
            return RedirectToPage("./Index");
        }
    }
}
