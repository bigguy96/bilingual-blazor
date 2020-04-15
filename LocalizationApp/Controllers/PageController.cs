using Microsoft.AspNetCore.Mvc;

namespace LocalizationApp.Controllers
{
    [Route("[controller]/[action]")]
    public class PageController : Controller
    {
        public IActionResult Index(string url)
        {
            if (url == null) url = "/";

            return LocalRedirect(url);
        }
    }
}