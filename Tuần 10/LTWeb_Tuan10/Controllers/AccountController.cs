using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_Tuan10.Controllers
{
    public class AccountController : Controller
    {
        QLSachEntities db = new QLSachEntities();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login_Check(string username, string password)
        {
            tblKhachHang found = db.tblKhachHangs.FirstOrDefault(s => s.Email == username);
            if (found != null && found.MatKhau == password)
            {
                Session["Username"] = found.TenKH;
                return RedirectToAction("Index", "Sach");
            }
            else
                return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Register_Save(tblKhachHang kh, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                if (Avatar == null && Request.Files.Count > 0)
                {
                    Avatar = Request.Files["Avatar"] ?? Request.Files[0];
                }

                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Avatar.FileName);
                    string Dir = "/Content/Images/";
                    string physicalDir = Server.MapPath(Dir);
                    if (!Directory.Exists(physicalDir))
                    {
                        Directory.CreateDirectory(physicalDir);
                    }
                    string path = Path.Combine(physicalDir, fileName);
                    Avatar.SaveAs(path);
                    kh.Avarta = Dir + fileName;
                }

                db.tblKhachHangs.Add(kh);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View("Register");
        }

        public ActionResult Logout()
        {
            Session.Remove("Username");
            return RedirectToAction("Login");
        }
    }
}
