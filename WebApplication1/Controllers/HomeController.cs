using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PowerUnitContainter.Containter.Dispose();
            ViewBag.Greeting = "전투를 시작합니다.";
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(PowerUnit guest)
        {   
            PowerUnitContainter.Containter.Add(guest);
            var result = new WarResult();
            result.Self = guest;
            result.Target = PowerUnitContainter.Containter.GetRamdom();
            
            result.NormalDamageToTarget();
            if (ModelState.IsValid)
            {
                return View("Thanks", result);
            }
            return View();
        }
    }
}