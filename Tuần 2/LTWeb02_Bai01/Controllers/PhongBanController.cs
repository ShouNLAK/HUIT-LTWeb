using LTWeb02_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai01.Controllers
{
    public class PhongBanController : Controller
    {
        // GET: PhongBan
        public ActionResult Index()
        {
            List<PhongBan> DS = new List<PhongBan>
{
                new PhongBan(1, "Phòng giám đốc"),
                new PhongBan(2, "Phòng kế hoạch"),
                new PhongBan(3, "Phòng kế toán"),
                new PhongBan(4, "Phòng sản xuất"),
                new PhongBan(5, "Phòng kinh doanh")
            };
            
            return View(DS);
        }
    }
}