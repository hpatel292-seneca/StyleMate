using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.ContentModel;
using StyleMate.Data;
using StyleMate.Models;
using StyleMate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StyleMate.Tests
{
    public class ClothingServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly ClothingService _clothingService;
        private readonly ApplicationDbContext dbContext;

        public ClothingServiceTests()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            dbContext = GetInMemoryDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.ClothingItem.AddRange(new List<ClothingItem>
            {
                new ClothingItem {Id=1,Type=ClothingType.Top, Color="Red", UserId="user1"},
                new ClothingItem {Id=2, Type=ClothingType.Bottom, Color="Blue", UserId="user2"}
            });
            dbContext.SaveChanges();
            _clothingService = new ClothingService(dbContext, _userManagerMock.Object);
        }

        [Theory]
        [InlineData("user1", 1)] // User with 1 item
        [InlineData("user2", 1)] // User with 1 item
        [InlineData("user3", 0)] // User with no items
        public void GetAllItems_ReturnsItemsForGivenUser(string userId, int expectedCount)
        {
            // Act
            var result = _clothingService.GetAllItems(userId);

            // Assert
            Assert.Equal(expectedCount, result.Count());
            if (expectedCount > 0)
            {
                Assert.All(result, item => Assert.Equal(userId, item.UserId));
            }
        }

        [Theory]
        [InlineData(1, "user1", true)]  // Valid ID and UserId, item exists
        [InlineData(2, "user2", true)]  // Valid ID and UserId, item exists
        [InlineData(3, "user1", false)] // Non-existent ID
        [InlineData(1, "user3", false)] // Non-existent UserId
        public void GetItemById_ReturnsItemsForGivenId(int id, string userId, bool exist)
        {
            // Act
            var result = _clothingService.GetItemById(id, userId);

            // Assert
            if (exist)
            {
                Assert.NotNull(result);
                Assert.Equal(userId, result.UserId);
                Assert.Equal(id, result.Id);
            }
            else
            {
                Assert.Null(result);
            }

        }

        [Fact]
        public async Task AddItemAsync_AddsItemForLoggedUser()
        {
            //Arrange
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user1")
            }));

            var newItem = new ClothingItem { Name = "Jacket", Type = ClothingType.Top, Color = "Black" };

            _userManagerMock.Setup(um => um.GetUserAsync(userPrincipal))
                .ReturnsAsync(new IdentityUser{Id = "user1"});

            // Act
            await _clothingService.AddItemAsync(newItem, userPrincipal);

            // Assert
            var addedItem = dbContext.ClothingItem.FirstOrDefault(i => i.Name == "Jacket");
            Assert.NotNull(addedItem);
            Assert.Equal("user1", addedItem.UserId);

        }

        [Fact]
        public async Task UpdateItemAsync_UpdateSelectedItem()
        {
            //Arrange
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user1")
            }));

            var newItem = new ClothingItem { Id=1,Name = "Jacket", Type = ClothingType.Top, Color = "Black" };

            _userManagerMock.Setup(um => um.GetUserAsync(userPrincipal))
                .ReturnsAsync(new IdentityUser { Id = "user1" });

            // Act
            await _clothingService.UpdateItemAsync(newItem, userPrincipal);

            // Assert
            var addedItem = dbContext.ClothingItem.FirstOrDefault(i => i.Id == 1);
            Assert.NotNull(addedItem);
            Assert.Equal("user1", addedItem.UserId);
            Assert.Equal("Jacket", addedItem.Name);
        }

        [Fact]
        public async Task DeleteItemAsync_DeleteSelectedItem()
        {
            //Arrange
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user1")
            }));

            var Id = 1;
            _userManagerMock.Setup(um => um.GetUserAsync(userPrincipal))
                .ReturnsAsync(new IdentityUser { Id = "user1" });

            // Act
            await _clothingService.DeleteItemAsync(Id, userPrincipal);

            //Assert
            var deletedItem = dbContext.ClothingItem.FirstOrDefault(i=>i.Id == Id);
            Assert.Null(deletedItem);
        }

        [Fact]
        public void FindMatches_ReturnsItemsWithDifferentType()
        {
            // Arrange
            var testItem = new ClothingItem { Type = ClothingType.Top };

            // Act
            var matches = _clothingService.FindMatches(testItem);

            // Assert
            Assert.All(matches, item => Assert.NotEqual(testItem.Type, item.Type));
        }
    }
}
