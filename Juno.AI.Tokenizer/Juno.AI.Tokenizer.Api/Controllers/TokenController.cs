using Juno.AI.Tokenizer.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Tokenizer.Api.Controllers
{
    [ApiController]
    [Route(Routes.Token)]
    public class TokenController : BaseController
    {
        private GptTokenizer tokenizer;
        public TokenController()
        {
            tokenizer = GptTokenizer.CreateTokenizerAsync().Result;
        }
        [HttpGet]
        [Route(Routes.TokenEstimate)]
        public async Task<IActionResult> Estimate(string message)
        {
            var tokens = tokenizer.GetTokens(message);
            return Ok(tokens.Length);
        }
    }
}
