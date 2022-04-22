using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace poc_oauth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public OAuthModel OAuthModel { get; set; }

        public void OnGet(string? code, string? status, string? token)
        {
            _logger.LogInformation("**** WE ZIJN BINNEN *****");
            OAuthModel = new OAuthModel();

            if (code != null)
            {
                OAuthModel.Code = code;
            }

            if (status != null)
            {
                OAuthModel.Status = status;
            }

            if (token != null)
            {
                OAuthModel.Status = token;
            }
        }
    }
}