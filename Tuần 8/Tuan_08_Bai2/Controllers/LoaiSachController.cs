using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuan_08_Bai2.Controllers
{
    public class LoaiSachController : Controller
    {
        QLSachEntities DB = new QLSachEntities();
        // GET: LoaiSach
        public ActionResult Index()
        {
            return View(DB.tblLoaiSach);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult CreateOnSubmit(tblLoaiSach loai)
        {
            if (ModelState.IsValid)
            {
                DB.tblLoaiSach.Add(loai);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}