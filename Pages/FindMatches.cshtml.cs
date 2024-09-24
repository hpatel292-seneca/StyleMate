using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using Markdig;
using System.Collections.Generic;
using System.Data;

namespace StyleMate.Pages
{
    public class FindMatchesModel : PageModel
    {
        private readonly IClothingService _clothingService;
        private readonly IClothingCombinationService _clothingCombinationService;
        private readonly IGroqService _groqService;

        public FindMatchesModel(IGroqService groqService, IClothingService clothingService, IClothingCombinationService clothingCombinationService)
        {
            _groqService = groqService;
            _clothingService = clothingService;
            _clothingCombinationService = clothingCombinationService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ClothingItem SelectedItem { get; set; }
        public IEnumerable<ClothingCombination> MatchingItems { get; set; }
        public string LLMresponse { get; set; }

        public async Task OnGet()
        {
            SelectedItem = _clothingService.GetItemById(Id);
            string prompt = "";
            if (SelectedItem != null)
            {
                if (SelectedItem.Type==ClothingType.Top)
                {
                    prompt = $"I have a top of {SelectedItem.Color} color and find me matches for this cloth";
                    MatchingItems = _clothingCombinationService.GetCombinationsByTop(top: SelectedItem.Color);
                }
                else if(SelectedItem.Type == ClothingType.Bottom){
                    prompt = $"I have a Bottom of {SelectedItem.Color} color and find me matches for this cloth";
                    MatchingItems = _clothingCombinationService.GetCombinationsByBottom(bottom: SelectedItem.Color);
                }
                else if (SelectedItem.Type == ClothingType.Shoe)
                {
                    prompt = $"I have a Shoe of {SelectedItem.Color} color and find me matches for this cloth";
                    MatchingItems = _clothingCombinationService.GetCombinationsByShoe(shoe: SelectedItem.Color);
                }
                //MatchingItems = _clothingService.FindMatches(SelectedItem);
            }


            LLMresponse = Markdown.ToHtml(await _groqService.GetChatCompletionAsync(prompt));
        }
    }
}
