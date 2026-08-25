using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai01.Controllers
{
    public class FruitController : Controller
    {
        // GET: Fruit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NhapDS()
        {
            List<string> DSFruit = new List<string>();
            DSFruit.Add("Cam");
            DSFruit.Add("Xoài");
            DSFruit.Add("Cóc");
            DSFruit.Add("Ổi");

            ViewBag.DuLieu = DSFruit;
            return View();
        }
    }
}