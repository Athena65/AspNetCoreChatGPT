using GenerateGPTBot.Models;

namespace GenerateGPTBot.Services
{
    public interface IBotAPIService
    {
        Task<List<string>> GenerateContent(ADGenerateRequestModelDTO requestModelDTO);
    }
}
