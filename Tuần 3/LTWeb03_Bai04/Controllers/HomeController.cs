using LTWeb03_Bai04.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace LTWeb03_Bai04.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<String> DS_Course = new List<String>()
            {
                "1. HTML CSS Bootstrap", "2. Learning C", "3. Learning Python"
            };
            ViewBag.Courses = new SelectList(DS_Course);
            return View();
        }
        [HttpPost]
        public ActionResult Info(Infomation obj, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (Picture != null)
                {
                    fileName = Picture.FileName;
                    string uploadDir = "~/Content/Images";
                    string PhysicalPath = Server.MapPath(uploadDir);
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    var path = Path.Combine(Server.MapPath(uploadDir), fileName);
                    Picture.SaveAs(path);
                    obj.FileImage = "/Content/Images" + "/" + fileName;
                }
                List<string> sources = new List<string>();
                if (obj.Check1) sources.Add("Television");
                if (obj.Check2) sources.Add("Website");
                if (obj.Check3) sources.Add("Newspaper");
                ViewBag.KnownByResult = sources.Any() ? string.Join(", ", sources) : "None";
                return View(obj);
            }
            return View("Index", obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}