using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Tuan_05.Models;

namespace Tuan_05.Controllers
{
    public class HomeController : Controller
    {
        DuLieu DB = new DuLieu();
        public ActionResult Index()
        {
            return View(DB.ds_PB);
        }

        public ActionResult ChiTiet(int id)
        {
            List<NhanVien> DSNV_Found;
            if (id != 0)
            {
                DSNV_Found = DB.ds_NV.Where(x => x.P_ID.Id == id).ToList();
                ViewBag.TenPhong = DB.ds_PB.First(x => x.Id == id).Name;
            }
                
            else
            {
                DSNV_Found = DB.ds_NV;
                ViewBag.TenPhong = "Hiển thị tất cả";
            }
                
            return View(DSNV_Found);
        }

        public ActionResult _showPB()
        {
            List<PhongBan> dspb = DB.ds_PB;
            return PartialView(dspb);
        }
    }
}