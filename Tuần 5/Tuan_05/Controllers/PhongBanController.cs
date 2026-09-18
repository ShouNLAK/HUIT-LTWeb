using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan_05.Models;

namespace Tuan_05.Controllers
{
    public class PhongBanController : Controller
    {

        DuLieu db = new DuLieu();
        // GET: PhongBan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XemChiTiet(int Id)
        {
            PhongBan pb = db.ds_PB.First(x=> x.Id == Id);
            return View(pb);
        }
    }
}