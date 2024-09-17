using Microsoft.EntityFrameworkCore;
using StyleMate.Models;

namespace StyleMate.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ClothingItem> ClothingItem { get; set; }
        public DbSet<ClothingCombination> ClothingCombination { get; set;}
    }
}
