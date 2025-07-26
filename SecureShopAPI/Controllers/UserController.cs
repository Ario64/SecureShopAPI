using Microsoft.AspNetCore.Mvc;

namespace SecureShopAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
