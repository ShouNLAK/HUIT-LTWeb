using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_Tuan10.Controllers
{
    public class LoaiSachController : Controller
    {
        QLSachEntities db = new QLSachEntities();
        // GET: LoaiSach
        public PartialViewResult List_TheLoai()
        {
            List<tblLoaiSach> list = db.tblLoaiSaches.ToList();
            return PartialView(list);
        }
    }
}