using StyleMate.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace StyleMate.Services
{
    public interface IClothingService
    {
        IEnumerable<ClothingItem> GetAllItems(string userId);
        ClothingItem GetItemById(int id, string userId);
        Task AddItemAsync(ClothingItem item, ClaimsPrincipal userPrincipal);
        Task UpdateItemAsync(ClothingItem item, ClaimsPrincipal userPrincipal);
        Task DeleteItemAsync(int id, ClaimsPrincipal userPrincipal);
        IEnumerable<ClothingItem> FindMatches(ClothingItem item);
    }
}
