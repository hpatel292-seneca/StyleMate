using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;
using System.Security.Claims;

namespace StyleMate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IClothingService _clothingService;

        public IndexModel(ILogger<IndexModel> logger, IClothingService clothingService)
        {
            _logger = logger;
            _clothingService = clothingService;
        }
        public IEnumerable<ClothingItem> Items { get; set; }

        public void OnGet()
        {
            // Retrieve the user ID of the currently logged-in user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Items = _clothingService.GetAllItems(userId);
        }
    }
}
