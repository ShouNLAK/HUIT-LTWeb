using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan_05.Models;

namespace Tuan_05.Controllers
{
    public class NhanVienController : Controller
    {
        DuLieu db = new DuLieu();
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XemChiTiet(int Id)
        {
            NhanVien nv = db.ds_NV.First(x => x.Id == Id);
            return View(nv);
        }
    }
}