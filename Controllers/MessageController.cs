using Microsoft.AspNetCore.Mvc;

namespace SignalRChatExample.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
