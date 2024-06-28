using StyleMate.Models;

namespace StyleMate.Services
{
    public class ClothingService : IClothingService
    {
        // holds clothing items.
        private readonly List<ClothingItem> _items;

        public ClothingService()
        {
            _items = new List<ClothingItem>
            {
                new ClothingItem { Id = 1, Name = "Brown T-Shirt", Type = ClothingType.Top, Color = "Brown" },
                new ClothingItem { Id = 2, Name = "Blue Jeans", Type = ClothingType.Bottom, Color = "Blue" }
            };
        }

        public IEnumerable<ClothingItem> GetAllItems()
        {
            return _items;
        }

        public ClothingItem GetItemById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }
        public void AddItem(ClothingItem item)
        {
            item.Id = _items.Max(i => i.Id) + 1;
            _items.Add(item);
        }

        public void UpdateItem(ClothingItem item)
        {
            var existingItem = GetItemById(item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Type = item.Type;
                existingItem.Color = item.Color;
            }
        }

        public void DeleteItem(int id)
        {
            var item = GetItemById(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
        public IEnumerable<ClothingItem> FindMatches(ClothingItem item)
        {
            // Simplified matching logic: just find items that are not the same type
            return _items.Where(i => i.Type != item.Type);
        }
    }
}
