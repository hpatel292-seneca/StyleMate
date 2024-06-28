using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;

namespace StyleMate.Pages
{
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
            ClothingItem = _clothingService.GetItemById(id);

            if (ClothingItem == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _clothingService.DeleteItem(id);
            return RedirectToPage("./Index");
        }
    }
}
