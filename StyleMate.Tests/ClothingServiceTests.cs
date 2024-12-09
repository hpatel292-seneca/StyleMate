using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using StyleMate.Data;
using StyleMate.Models;
using StyleMate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleMate.Tests
{
    public class ClothingServiceTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly ClothingService _clothingService;

        public ClothingServiceTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            var mockUserStore = new Mock<IUserStore<IdentityUser>>();

            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                mockUserStore.Object
            );
            var mockClothingItems = new List<ClothingItem>
            {
                new ClothingItem {Id=1, Type=ClothingType.Top, Color="Red", UserId="user1"},
                new ClothingItem {Id=2, Type=ClothingType.Bottom, Color="Blue", UserId="user2"}
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<ClothingItem>>();
            mockDbSet.As<IQueryable<ClothingItem>>().Setup(m => m.Provider).Returns(mockClothingItems.Provider);
            mockDbSet.As<IQueryable<ClothingItem>>().Setup(m => m.Expression).Returns(mockClothingItems.Expression);
            mockDbSet.As<IQueryable<ClothingItem>>().Setup(m => m.ElementType).Returns(mockClothingItems.ElementType);
            mockDbSet.As<IQueryable<ClothingItem>>().Setup(m => m.GetEnumerator()).Returns(mockClothingItems.GetEnumerator());

            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(c => c.ClothingItem).Returns(mockDbSet.Object);


            _clothingService = new ClothingService(_mockContext.Object, _mockUserManager.Object);
        }
    }
}
