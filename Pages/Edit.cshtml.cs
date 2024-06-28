using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;

namespace StyleMate.Pages
{
    public class EditModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public EditModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clothingService.UpdateItem(ClothingItem);
            return RedirectToPage("./Index");
        }
    }
}
