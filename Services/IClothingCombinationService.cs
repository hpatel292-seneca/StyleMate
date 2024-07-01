using StyleMate.Models;

namespace StyleMate.Services
{
    public interface IClothingCombinationService
    {
        List<ClothingCombination> GetAllCombinations();
        List<ClothingCombination> GetCombinationsByBottom(string bottom);
        List<ClothingCombination> GetCombinationsByShoe(string shoe);
        List<ClothingCombination> GetCombinationsByTop(string top);
    }
}