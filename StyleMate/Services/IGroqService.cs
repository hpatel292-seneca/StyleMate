
namespace StyleMate.Services
{
    public interface IGroqService
    {
        Task<string> GetChatCompletionAsync(string prompt);
    }
}