using System;
using Microsoft.AspNetCore.Mvc;

namespace zmanimapi.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Help(){
            return View();
        }
        public IActionResult ZmanimHelp(){
            return View();
        }
        public IActionResult CalendarHelp(){
            return View();
        }
    }
}
