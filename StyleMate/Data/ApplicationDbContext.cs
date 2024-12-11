using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StyleMate.Models;

namespace StyleMate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClothingItem> ClothingItem { get; set; }
        public DbSet<ClothingCombination> ClothingCombination { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Store ClothingType as a string in the database
            modelBuilder.Entity<ClothingItem>()
                .Property(ci => ci.Type)
                .HasConversion<string>();
        }
    }
}
