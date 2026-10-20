using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_Tuan10.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QLSachEntities db = new QLSachEntities();
        // GET: NhaXuatBan
        public PartialViewResult List_NhaXuatBan()
        {
            List<tblNXB> list = db.tblNXBs.ToList();
            return PartialView(list);
        }
    }
}