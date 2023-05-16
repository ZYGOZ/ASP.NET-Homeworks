using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_HomeWork_1.Pages
{
    public class IndexModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Message1 = DateTime.Now.ToString();
        }
        public void OnPost()
        {
            Message1 = DateTime.Now.ToString();
            Message2 = "A";
        }
    }
}