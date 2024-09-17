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

            if (!_context.ClothingCombination.Any())
            {
                var combinations = new List<ClothingCombination>
            {
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "Beige/Khaki Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },
                new ClothingCombination { Top = "Brown T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },

                new ClothingCombination {  Top = "White T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination {  Top = "White T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination {  Top = "White T-Shirt", Bottom = "Grey Pants", Shoe = "White Sneakers" },
                new ClothingCombination {  Top = "White T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination {  Top = "White T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },

                new ClothingCombination { Top = "Black T-Shirt", Bottom = "Grey Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Top = "Black T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Black T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Black T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Black T-Shirt", Bottom = "Olive Green Pants", Shoe = "Black Boots" },

                new ClothingCombination { Top = "Navy Blue T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination { Top = "Navy Blue T-Shirt", Bottom = "Grey Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Navy Blue T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Navy Blue T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },
                new ClothingCombination { Top = "Navy Blue T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },

                new ClothingCombination { Top = "Grey T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Grey T-Shirt", Bottom = "Blue Jeans", Shoe = "Grey Shoes" },
                new ClothingCombination { Top = "Grey T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Grey T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Grey T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },

                new ClothingCombination { Top = "Red T-Shirt", Bottom = "Dark Blue Jeans", Shoe = "Black Boots" },
                new ClothingCombination { Top = "Red T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Red T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Red T-Shirt", Bottom = "Khaki Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Red T-Shirt", Bottom = "White Pants", Shoe = "Red Shoes" },

                new ClothingCombination { Top = "Green T-Shirt", Bottom = "Beige Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Green T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Green T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Top = "Green T-Shirt", Bottom = "White Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Green T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },

                new ClothingCombination { Top = "Yellow T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Yellow T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Top = "Yellow T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination { Top = "Yellow T-Shirt", Bottom = "Grey Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Yellow T-Shirt", Bottom = "White Pants", Shoe = "Yellow Shoes" },

                new ClothingCombination { Top = "Pink T-Shirt", Bottom = "White Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Top = "Pink T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Top = "Pink T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Top = "Pink T-Shirt", Bottom = "Grey Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Top = "Pink T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" }

            };
                _context.ClothingCombination.AddRange(combinations);
                _context.SaveChanges();
            }
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
