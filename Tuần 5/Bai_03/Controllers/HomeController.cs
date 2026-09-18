using Bai_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_03.Controllers
{
    public class HomeController : Controller
    {
        DuLieu db = new DuLieu();
        public ActionResult Index(int? MaLoai, string SearchString)
        {
            List<SanPham> DSSP;
            if (MaLoai != null && MaLoai != 0)
            {
                DSSP = db.ds_SP
                         .Where(sp => sp.MaLoai.MaLoai == MaLoai)
                         .ToList();
                
                var loai = db.ds_Loai.FirstOrDefault(x => x.MaLoai == MaLoai);
                ViewBag.TenLoai = loai != null ? loai.TenLoai : "Không xác định";
            }
            else
            {
                DSSP = db.ds_SP;
                ViewBag.TenLoai = "Tất cả";
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                DSSP = DSSP.Where(sp => sp.TenSP.ToLower().Contains(SearchString.ToLower())).ToList();
            }

            ViewBag.CurrentFilter = SearchString;

            ViewBag.MaLoai = new SelectList(db.ds_Loai, "MaLoai", "TenLoai", MaLoai);

            return View(DSSP);
        }

        public ActionResult _showLoai()
        {
            return PartialView(db.ds_Loai);
        }
    }
}