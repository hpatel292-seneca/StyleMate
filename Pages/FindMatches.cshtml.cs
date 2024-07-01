using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using System.Collections.Generic;
using System.Data;

namespace StyleMate.Pages
{
    public class FindMatchesModel : PageModel
    {
        private readonly IClothingService _clothingService;
        private readonly IClothingCombinationService _clothingCombinationService;

        public FindMatchesModel(IClothingService clothingService, IClothingCombinationService clothingCombinationService)
        {
            _clothingService = clothingService;
            _clothingCombinationService = clothingCombinationService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ClothingItem SelectedItem { get; set; }
        public IEnumerable<ClothingCombination> MatchingItems { get; set; }

        public void OnGet()
        {
            SelectedItem = _clothingService.GetItemById(Id);
            if (SelectedItem != null)
            {
                if (SelectedItem.Type==ClothingType.Top)
                {
                    MatchingItems = _clothingCombinationService.GetCombinationsByTop(top: SelectedItem.Color);
                }
                //MatchingItems = _clothingService.FindMatches(SelectedItem);
            }
        }
    }
}
