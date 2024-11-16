using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using Markdig;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StyleMate.Pages
{
    [Authorize]
    public class FindMatchesModel : PageModel
    {
        private readonly IClothingService _clothingService;
        private readonly IClothingCombinationService _clothingCombinationService;
        private readonly IGroqService _groqService;
        private readonly IWeatherService _weatherService;

        public FindMatchesModel(IGroqService groqService, IClothingService clothingService, IClothingCombinationService clothingCombinationService, IWeatherService weatherService)
        {
            _groqService = groqService;
            _clothingService = clothingService;
            _clothingCombinationService = clothingCombinationService;
            _weatherService = weatherService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ClothingItem SelectedItem { get; set; }
        public IEnumerable<ClothingCombination> MatchingItems { get; set; }
        public string LLMresponse { get; set; }

        public async Task OnGet()
        {
            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SelectedItem = _clothingService.GetItemById(Id, userId);
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
                // Fetch weather details for a default or user-specified city
                string city = "Toronto"; // You can replace this with a dynamic input if needed
                var weather = await _weatherService.GetWeatherAsync(city);
                string WeatherDetails;

                if (weather != null)
                {
                    // Prepare weather details string for the prompt
                    WeatherDetails = $"The current weather in {city} is {weather.Main.Temp}°C with {weather.Weather.First().Description}.";
                }
                else
                {
                    WeatherDetails = "Unable to fetch weather details at this time.";
                }

                // Append weather details to the prompt
                prompt += $" Consider the following weather context: {WeatherDetails}";
            }


            LLMresponse = Markdown.ToHtml(await _groqService.GetChatCompletionAsync(prompt));
        }
    }
}
