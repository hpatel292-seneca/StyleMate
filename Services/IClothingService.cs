using StyleMate.Models;
using System.Collections.Generic;

namespace StyleMate.Services
{
    public interface IClothingService
    {
        IEnumerable<ClothingItem> GetAllItems();
        ClothingItem GetItemById(int id);
        void AddItem(ClothingItem item);
        void UpdateItem(ClothingItem item);
        void DeleteItem(int id);
        IEnumerable<ClothingItem> FindMatches(ClothingItem item);
    }
}
