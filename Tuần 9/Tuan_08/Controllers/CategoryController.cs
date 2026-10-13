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

        public ActionResult Edit(int id)
        {
            return View(DB.Categories.Find(id));
        }

        public ActionResult Delete(int id)
        {
            return View(DB.Categories.Find(id));
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

        public ActionResult EditOnSubmit(Categories cate)
        {
            if (ModelState.IsValid)
            {
                var category = DB.Categories.Find(cate.CategoryID);
                if (category != null)
                {
                    category.CategoryName = cate.CategoryName;
                    category.Description = cate.Description;
                    DB.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOnSubmit(Categories cate)
        {
            if(ModelState.IsValid)
            {
                Categories found = DB.Categories.Find(cate.CategoryID);
                if (found != null)
                {
                    DB.Categories.Remove(found);
                    DB.SaveChanges();
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}