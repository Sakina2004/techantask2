using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Techannnntaskk.Controllers
{
    public class HomeController : Controller
    {
        private readonly Test _test;
        private readonly Test2 _test2;
       
        public HomeController(Test t,Test2 test2)
        {
            _test = t;
            _test2 = test2;
        }

        public IActionResult Index()
        {
            _test2.Salam();
            return View();
        }

      

      
    }
}
