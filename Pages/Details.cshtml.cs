using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;

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
            ClothingItem = _clothingService.GetItemById(id);

            if (ClothingItem == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
