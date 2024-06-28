using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using System.Collections.Generic;

namespace StyleMate.Pages
{
    public class FindMatchesModel : PageModel
    {
        private readonly IClothingService _clothingService;

        public FindMatchesModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ClothingItem SelectedItem { get; set; }
        public IEnumerable<ClothingItem> MatchingItems { get; set; }

        public void OnGet()
        {
            SelectedItem = _clothingService.GetItemById(Id);
            if (SelectedItem != null)
            {
                MatchingItems = _clothingService.FindMatches(SelectedItem);
            }
        }
    }
}
