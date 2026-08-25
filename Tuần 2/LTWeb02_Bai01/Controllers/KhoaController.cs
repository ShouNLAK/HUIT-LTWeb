using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai01.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        public ActionResult Index()
        {
            Models.Khoa khoaCNTT = new Models.Khoa();
            khoaCNTT.Message = "FIT-HUIT: HỌC TẬP - NĂNG ĐỘNG - SÁNG TẠO";
            return View(khoaCNTT);
        }
    }
}