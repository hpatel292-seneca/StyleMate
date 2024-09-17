using Microsoft.EntityFrameworkCore;
using StyleMate.Data;
using StyleMate.Models;

namespace StyleMate.Services
{
    public class ClothingCombinationService : IClothingCombinationService
    {
        private readonly ApplicationDbContext _context;

        public ClothingCombinationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ClothingCombination> GetAllCombinations()
        {
            return _context.ClothingCombination.ToList();
        }

        public List<ClothingCombination> GetCombinationsByTop(string top)
        {
            return _context.ClothingCombination.ToList()
                .Where(c => c.Top.StartsWith(top, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<ClothingCombination> GetCombinationsByBottom(string bottom)
        {
            return _context.ClothingCombination.ToList()
                .Where(c=>c.Bottom.StartsWith(bottom, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<ClothingCombination> GetCombinationsByShoe(string shoe)
        {
            return _context.ClothingCombination.ToList()
                .Where(c => c.Shoe.StartsWith(shoe, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
