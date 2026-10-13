using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ActionResult Edit(int id)
        {
            return View(DB.tblLoaiSach.Find(id));
        }

        public ActionResult Delete(int id)
        {
            return View(DB.tblLoaiSach.Find(id));
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

        public ActionResult EditOnSubmit (tblLoaiSach loai)
        {
            if (ModelState.IsValid)
            {
                var loaiSach = DB.tblLoaiSach.Find(loai.MaLoai);
                if (loaiSach != null)
                {
                    loaiSach.TenLoai = loai.TenLoai;
                    loaiSach.GhiChu = loai.GhiChu;
                    DB.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOnSubmit(tblLoaiSach loai)
        {
            tblLoaiSach loaiSach = DB.tblLoaiSach.FirstOrDefault(x => x.MaLoai == loai.MaLoai);
            var relatedBooks = DB.tblSach.Where(x => x.LoaiSach == loai.MaLoai).ToList();
            if (relatedBooks.Count > 0)
            {
                DB.tblSach.RemoveRange(relatedBooks);
            }
            DB.tblLoaiSach.Remove(loaiSach);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}