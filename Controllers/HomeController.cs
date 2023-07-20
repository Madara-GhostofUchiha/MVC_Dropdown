using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dropdown.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult index()
        {
            ViewBag.Countries = new List<string>()
            {
                "india",
                "africa",
                "USA",
                "ussr"
            };

            return View();
            
        }
        public string GetDetails()
        {
            return "GetDetails Invoked";
        }
    }
}