using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTTL_3.Models;

namespace BTTL_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MonAn(int? id)
        {
            List<Product> products = Data.GetProducts();
            if (id.HasValue)
            {
                products = products.Where(p => p.CategoryId == id.Value).ToList();
            }
            
            return View(products);
        }

        public ActionResult _Menu()
        {
            List<Category> categories = Data.GetCategories();
            return PartialView(categories);
        }
    }
}