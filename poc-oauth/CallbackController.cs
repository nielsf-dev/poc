using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace poc_oauth
{
    [ApiController]
    public class CallbackController : Controller
    {
        private readonly ILogger<CallbackController> logger;
        private readonly HttpClient client;

        public CallbackController(ILogger<CallbackController> logger)
        {
            this.client = new HttpClient();
            this.logger = logger;
        }

        [HttpGet]
        [Route("/callback")]
        public async Task<IActionResult> CallBack(string code)
        {
            var url = $"https://cloud.digitalocean.com/v1/oauth/token?client_id=e6416a79961950a29f5922e4ff6a12b09e5d51938397d67ad13b817f613e6b98&client_secret=e67a1babcfd9452cb18e0b512d0bc5cf2bfd5eaa6f8607217c9b201d2808d959&grant_type=authorization_code&code={code}&redirect_uri=https://poc-oauth.azurewebsites.net/callback";
            var httpResponseMessage = await client.PostAsync(url, new StringContent(""));
            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            logger.LogInformation("The result is = {result}", resultString);

            logger.LogInformation("The code is {code}", code);
            return Redirect($"/Index?code={code}&status={httpResponseMessage.StatusCode}");
        }

        [HttpPost]
        [Route("/callback")]
        public IActionResult TokenCallBack(string token)
        {
            logger.LogInformation("The token is {token}", token);
            return Redirect($"/Index?token=tochiets");
        }

    }
}
