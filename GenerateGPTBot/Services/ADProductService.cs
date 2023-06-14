using GenerateGPTBot.Models;

namespace GenerateGPTBot.Services
{
    public class ADProductService : IADProductService
    {
        private readonly IBotAPIService _aPIService;

        public ADProductService(IBotAPIService aPIService)
        {
            _aPIService = aPIService;
        }
        public async Task<ADProductResponseModel> GenerateAdContent(CustomerRequestModel customerRequest)
        {
            if (String.IsNullOrEmpty(customerRequest.Message))
            {
                return new ADProductResponseModel
                {
                    ADContent=null,
                    Success=false
                };
            }
            ADGenerateRequestModelDTO userMessage = new ADGenerateRequestModelDTO
            {
                Prompt = customerRequest.Message
            };
            var generateAD = await _aPIService.GenerateContent(userMessage);
            if (generateAD.Count == 0)
            {
                return new ADProductResponseModel
                {
                    Success = false,
                    ADContent = null
                };
            }
            return new ADProductResponseModel
            {
                Success = true,
                ADContent = generateAD
            };
        }
    }
}
