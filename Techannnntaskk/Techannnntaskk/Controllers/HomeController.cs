using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Techannnntaskk.Controllers
{
    public class HomeController : Controller
    {

        private readonly INotify _notification;

        public HomeController(INotify _notification)
        {
            _notification = _notification;
        }

        public IActionResult Index()
        {
           
            _notification.Send("0773297427");
            return View();
        }

      

      
    }
}
