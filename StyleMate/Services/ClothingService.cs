using Microsoft.AspNetCore.Identity;
using StyleMate.Data;
using StyleMate.Models;
using System.Security.Claims;

namespace StyleMate.Services
{
    public class ClothingService : IClothingService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ClothingService(ApplicationDbContext context, UserManager<IdentityUser> user)
        {
            _context = context;
            _userManager = user;
        }

        public IEnumerable<ClothingItem> GetAllItems(string userId)
        {
            // Retrieve only items belonging to the current user
            return _context.ClothingItem.Where(item => item.UserId == userId).ToList();
        }
        public ClothingItem GetItemById(int id, string userId)
        {
            return _context.ClothingItem.FirstOrDefault(item => item.Id == id && item.UserId==userId);
        }
        public async Task AddItemAsync(ClothingItem item, ClaimsPrincipal userPrincipal)
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null) return;

            // Set the item's UserId to the current user's ID
            item.UserId = user.Id;

            _context.ClothingItem.Add(item);
            _context.SaveChanges();
        }

        public async Task UpdateItemAsync(ClothingItem item, ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            var existingItem = _context.ClothingItem.FirstOrDefault(i => i.Id == item.Id && i.UserId == user.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Type = item.Type;
                existingItem.Color = item.Color;

                _context.SaveChanges();
            }
        }

        public async Task DeleteItemAsync(int id, ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            var item = _context.ClothingItem.FirstOrDefault(i => i.Id == id && i.UserId == user.Id);
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
