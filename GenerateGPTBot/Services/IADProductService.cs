using GenerateGPTBot.Models;

namespace GenerateGPTBot.Services
{
    public interface IADProductService
    {
        Task<ADProductResponseModel> GenerateAdContent(CustomerRequestModel customerRequest);
    }
}
