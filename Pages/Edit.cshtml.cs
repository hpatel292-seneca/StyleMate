using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> ClothingTypes { get; set; }

        public IActionResult OnGet(int id)
        {
            ClothingTypes = GetClothingTypes();
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
