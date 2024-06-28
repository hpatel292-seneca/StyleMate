using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleMate.Models;
using StyleMate.Services;

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
            Items = _clothingService.GetAllItems();
        }
    }
}
