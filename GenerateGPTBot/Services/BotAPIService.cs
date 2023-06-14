using GenerateGPTBot.Models;
using OpenAI_API;

namespace GenerateGPTBot.Services
{
    public class BotAPIService : IBotAPIService
    {
        private readonly IConfiguration _config;

        public BotAPIService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<string>> GenerateContent(ADGenerateRequestModelDTO requestModelDTO)
        {
            var apiKey = _config.GetSection("Appsettings:ChatGPTAPIKEY").Value;
            var apiModel = _config.GetSection("Appsettings:Model").Value;
            List<string> request = new List<string>();
            string? response = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            OpenAI_API.Completions.CompletionRequest completionRequest =new OpenAI_API.Completions.CompletionRequest
            {
                Prompt= requestModelDTO.Prompt,
                Model=apiModel,
                Temperature=0.5,
                MaxTokens=100,
                TopP=1.0,
                FrequencyPenalty=0.0,
                PresencePenalty=0.0
            };
            var result= await api.Completions.CreateCompletionAsync(completionRequest); 
            foreach(var choice in result.Completions)
            {
                response = choice.Text;
                request.Add(choice.Text);
            }
            return request;

        }
    }
}
