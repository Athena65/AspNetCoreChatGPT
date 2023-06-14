using GenerateGPTBot.Models;
using GenerateGPTBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenerateGPTBot.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ChatGPTController : ControllerBase
    {
        private readonly IADProductService _adProduct;

        public ChatGPTController(IADProductService adProduct)
        {
            _adProduct = adProduct;
        }
        [HttpPost]
        public async Task<ActionResult<ADProductResponseModel>> GenerateAD(CustomerRequestModel request)
        {
            try
            {
               return await _adProduct.GenerateAdContent(request);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
