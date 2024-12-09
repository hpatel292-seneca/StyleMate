using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleMate.Models;
using StyleMate.Services;
using System.Security.Claims;

namespace StyleMate.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public EditModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty]
        public ClothingItem ClothingItem { get; set; }
        public IEnumerable<SelectListItem> ClothingTypes { get; set; }

        public IActionResult OnGet(int id)
        {
            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve the item for the current user
            ClothingItem = _clothingService.GetItemById(id, userId);
            ClothingTypes = GetClothingTypes();

            if (ClothingItem == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check that the item belongs to the current user before updating
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingItem = _clothingService.GetItemById(ClothingItem.Id, userId);

            if (existingItem == null)
            {
                // Redirect to Index if the item doesn't exist or doesn't belong to the user
                return RedirectToPage("./Index");
            }

            // Update the item
            await _clothingService.UpdateItemAsync(ClothingItem, User);
            return RedirectToPage("./Index");
        }
        private IEnumerable<SelectListItem> GetClothingTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = ClothingType.Top.ToString(), Text = "Top" },
                new SelectListItem { Value = ClothingType.Bottom.ToString(), Text = "Bottom" },
                new SelectListItem { Value = ClothingType.Shoe.ToString(), Text = "Shoe" }
            };
        }
    }
}
