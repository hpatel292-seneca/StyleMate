using StyleMate.Data;
using StyleMate.Models;

namespace StyleMate.Services
{
    public class ClothingService : IClothingService
    {
        private readonly ApplicationDbContext _context;
        public ClothingService(ApplicationDbContext context)
        {
            _context = context;
            // Initialize data if no items exist
            if (!_context.ClothingItem.Any())
            {
                var items = new List<ClothingItem>
            {
                new ClothingItem { Name = "Brown T-Shirt", Type = ClothingType.Top, Color = "Brown" },
                new ClothingItem { Name = "Blue Jeans", Type = ClothingType.Bottom, Color = "Blue" }
            };
                _context.ClothingItem.AddRange(items);
                _context.SaveChanges();
            }
            
        }

        public IEnumerable<ClothingItem> GetAllItems()
        {
            return _context.ClothingItem.ToList();
        }
        public ClothingItem GetItemById(int id)
        {
            return _context.ClothingItem.FirstOrDefault(item => item.Id == id);
        }
        public void AddItem(ClothingItem item)
        {
            // Add a new clothing item to the database
            _context.ClothingItem.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(ClothingItem item)
        {
            var existingItem=_context.ClothingItem.FirstOrDefault(i=>i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Type = item.Type;
                existingItem.Color = item.Color;

                _context.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
            var item = _context.ClothingItem.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _context.ClothingItem.Remove(item);
                _context.SaveChanges();
            }
        }
        public IEnumerable<ClothingItem> FindMatches(ClothingItem item)
        {
            // Simplified matching logic: just find items that are not the same type
            return _context.ClothingItem.Where(i => i.Type != item.Type).ToList();
        }
    }
}
