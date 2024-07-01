using StyleMate.Models;

namespace StyleMate.Services
{
    public class ClothingCombinationService : IClothingCombinationService
    {
        private readonly List<ClothingCombination> _combinations;

        public ClothingCombinationService()
        {
            _combinations = new List<ClothingCombination>
            {
                new ClothingCombination { Id = 1, Top = "Brown T-Shirt", Bottom = "Beige/Khaki Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 2, Top = "Brown T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 3, Top = "Brown T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 4, Top = "Brown T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 5, Top = "Brown T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },
                new ClothingCombination { Id = 6, Top = "Brown T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },

                new ClothingCombination { Id = 7, Top = "White T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 8, Top = "White T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 9, Top = "White T-Shirt", Bottom = "Grey Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 10, Top = "White T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination { Id = 11, Top = "White T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },

                new ClothingCombination { Id = 12, Top = "Black T-Shirt", Bottom = "Grey Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 13, Top = "Black T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 14, Top = "Black T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 15, Top = "Black T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 16, Top = "Black T-Shirt", Bottom = "Olive Green Pants", Shoe = "Black Boots" },

                new ClothingCombination { Id = 17, Top = "Navy Blue T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination { Id = 18, Top = "Navy Blue T-Shirt", Bottom = "Grey Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 19, Top = "Navy Blue T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 20, Top = "Navy Blue T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },
                new ClothingCombination { Id = 21, Top = "Navy Blue T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },

                new ClothingCombination { Id = 22, Top = "Grey T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 23, Top = "Grey T-Shirt", Bottom = "Blue Jeans", Shoe = "Grey Shoes" },
                new ClothingCombination { Id = 24, Top = "Grey T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 25, Top = "Grey T-Shirt", Bottom = "Olive Green Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 26, Top = "Grey T-Shirt", Bottom = "White Pants", Shoe = "Navy Blue Shoes" },

                new ClothingCombination { Id = 27, Top = "Red T-Shirt", Bottom = "Dark Blue Jeans", Shoe = "Black Boots" },
                new ClothingCombination { Id = 28, Top = "Red T-Shirt", Bottom = "Black Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 29, Top = "Red T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 30, Top = "Red T-Shirt", Bottom = "Khaki Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 31, Top = "Red T-Shirt", Bottom = "White Pants", Shoe = "Red Shoes" },

                new ClothingCombination { Id = 32, Top = "Green T-Shirt", Bottom = "Beige Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 33, Top = "Green T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 34, Top = "Green T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 35, Top = "Green T-Shirt", Bottom = "White Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 36, Top = "Green T-Shirt", Bottom = "Grey Pants", Shoe = "Brown Shoes" },

                new ClothingCombination { Id = 37, Top = "Yellow T-Shirt", Bottom = "Blue Jeans", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 38, Top = "Yellow T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 39, Top = "Yellow T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Loafers" },
                new ClothingCombination { Id = 40, Top = "Yellow T-Shirt", Bottom = "Grey Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 41, Top = "Yellow T-Shirt", Bottom = "White Pants", Shoe = "Yellow Shoes" },

                new ClothingCombination { Id = 42, Top = "Pink T-Shirt", Bottom = "White Pants", Shoe = "White Sneakers" },
                new ClothingCombination { Id = 43, Top = "Pink T-Shirt", Bottom = "Blue Jeans", Shoe = "Brown Shoes" },
                new ClothingCombination { Id = 44, Top = "Pink T-Shirt", Bottom = "Black Pants", Shoe = "Black Shoes" },
                new ClothingCombination { Id = 45, Top = "Pink T-Shirt", Bottom = "Grey Pants", Shoe = "Tan Shoes" },
                new ClothingCombination { Id = 46, Top = "Pink T-Shirt", Bottom = "Khaki Pants", Shoe = "Brown Shoes" }

            };
        }
        public List<ClothingCombination> GetAllCombinations()
        {
            return _combinations;
        }

        public List<ClothingCombination> GetCombinationsByTop(string top)
        {
            return _combinations.Where(c => c.Top.StartsWith(top, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<ClothingCombination> GetCombinationsByBottom(string bottom)
        {
            return _combinations.Where(c => c.Bottom.StartsWith(bottom, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<ClothingCombination> GetCombinationsByShoe(string shoe)
        {
            return _combinations.Where(c => c.Shoe.StartsWith(shoe, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
