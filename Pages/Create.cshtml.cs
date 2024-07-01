using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StyleMate.Models;
using StyleMate.Services;

namespace StyleMate.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public CreateModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty]
        public ClothingItem clothingItem { get; set; }
       
        public IEnumerable<SelectListItem> ClothingTypes { get; set; }
        public void OnGet()
        {
            ClothingTypes = GetClothingTypes();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _clothingService.AddItem(clothingItem);
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