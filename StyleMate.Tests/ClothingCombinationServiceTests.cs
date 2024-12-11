using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StyleMate.Data;
using StyleMate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleMate.Tests
{
    public class ClothingCombinationServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }
        private readonly ApplicationDbContext dbContext;
        private readonly ClothingCombinationService _ClothingCombinationService;

        public ClothingCombinationServiceTests()
        {
            dbContext = GetInMemoryDbContext();
            _ClothingCombinationService = new ClothingCombinationService(dbContext);
        }

        [Fact]
        public void GetAllCombination_ShouldReturnAllCombination()
        {
            // Act
            var result = _ClothingCombinationService.GetAllCombinations();

            // Assert
            Assert.Equal(46, result.Count);
        }

        [Theory]
        [InlineData("Brown", 6)]
        [InlineData("White", 5)]
        [InlineData("abc", 0)]
        public void GetCombinationByTop_ShouldReturnCombinationByTop(string top, int expected)
        {
            // Act
            var result = _ClothingCombinationService.GetCombinationsByTop(top);

            // Assert
            Assert.Equal(expected, result.Count);
            if (expected > 0)
            {
                Assert.All(result, combination => Assert.StartsWith(top, combination.Top, StringComparison.OrdinalIgnoreCase));
            }
        }
        
        [Theory]
        [InlineData("Blue", 8)]
        [InlineData("abc", 0)]
        public void GetCombinationByButton_ShouldReturnCombinationByButton(string Buttom, int expected)
        {
            // Act
            var result = _ClothingCombinationService.GetCombinationsByBottom(Buttom);

            // Assert
            Assert.Equal(expected, result.Count);
            if (expected > 0)
            {
                Assert.All(result, combination => Assert.StartsWith(Buttom, combination.Bottom, StringComparison.OrdinalIgnoreCase));
            }
        }
        
        [Theory]
        [InlineData("Brown", 13)]
        [InlineData("abc", 0)]
        public void GetCombinationByTop_ShouldReturnCombinationByShoe(string Shoe, int expected)
        {
            // Act
            var result = _ClothingCombinationService.GetCombinationsByShoe(Shoe);

            // Assert
            Assert.Equal(expected, result.Count);
            if (expected > 0)
            {
                Assert.All(result, combination => Assert.StartsWith(Shoe, combination.Shoe, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
    
}
