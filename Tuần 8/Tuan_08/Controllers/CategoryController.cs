using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuan_08.Controllers
{
    public class CategoryController : Controller
    {

        QLTinTucEntities DB = new QLTinTucEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View(DB.Categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult CreateOnSubmit(Categories cate)
        {
            if (ModelState.IsValid)
            {
                DB.Categories.Add(cate);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}