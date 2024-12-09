using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GroqNet;
using GroqNet.ChatCompletions;

namespace StyleMate.Services
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly GroqClient _groqClient;

        public GroqService(HttpClient httpClient, IConfiguration configuration, GroqClient groqClient)
        {
            _groqClient = groqClient;
            _httpClient = httpClient;
            _apiKey = configuration.GetConnectionString("GROQ_API_KEY");  // Set this key in your appsettings.json or environment variable
        }

        public async Task<string> GetChatCompletionAsync(string prompt)
        {
            string newprompt = $"you are an intelligent fashion assistant on a website that helps users choose matching outfits based on their clothing input. When a user provides an item of clothing (e.g., a black t-shirt), suggest complementary bottoms and shoes that will match the given item. Ensure your responses are fashion-forward, appropriate for the context (casual, formal, etc.), and provide brief explanations for your choices.\r\n\r\nFor example:\r\n\r\nIf a user enters \"black t-shirt,\" you might suggest dark jeans and white sneakers for a casual look or grey chinos and black loafers for a smart-casual outfit. User message: {prompt}";
            // Create chat history with the user prompt
            var history = new GroqChatHistory
        {
            new(newprompt)
        };

            // Get chat completion from the GroqClient
            var result = await _groqClient.GetChatCompletionsAsync(history);

            // Return the result content
            return result.Choices.First().Message.Content;
            //try
            //{


            //    var requestUrl = "https://api.groq.com/openai/v1/chat/completions";
            //    var requestBody = new
            //    {
            //        message = new[]
            //        {
            //        new {role="system", content="you are an intelligent fashion assistant on a website that helps users choose matching outfits based on their clothing input. When a user provides an item of clothing (e.g., a black t-shirt), suggest complementary bottoms and shoes that will match the given item. Ensure your responses are fashion-forward, appropriate for the context (casual, formal, etc.), and provide brief explanations for your choices.\r\n\r\nFor example:\r\n\r\nIf a user enters \"black t-shirt,\" you might suggest dark jeans and white sneakers for a casual look or grey chinos and black loafers for a smart-casual outfit."},
            //        new {role="user", content= prompt }
            //    },
            //        model = "llama3-8b-8192"
            //    };

            //    var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            //    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            //    // Making the POST request to Groq API
            //    var response = await _httpClient.PostAsync(requestUrl, jsonContent);

            //    // Ensure the request succeeded
            //    response.EnsureSuccessStatusCode();

            //    // Reading and returning the response content
            //    return await response.Content.ReadAsStringAsync();
            //}
            //catch (Exception ex) {
            //    // Log full exception
            //    Console.WriteLine(ex.ToString());
            //    return "An error occurred: " + ex.Message;
            //}


        }
    }
}
