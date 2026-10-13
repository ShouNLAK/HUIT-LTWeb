using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Tuan_08.Controllers
{
    public class NewsController : Controller
    {
        QLTinTucEntities DB = new QLTinTucEntities();
        // GET: News
        public ActionResult Index()
        {
            return View(DB.News);
        }

        public ActionResult Add()
        {
            ViewBag.Category = new SelectList(DB.Categories,"CategoryID","CategoryName");
            ViewBag.Author = new SelectList(DB.Authors, "AuthorID", "AuthorName");
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Category = new SelectList(DB.Categories, "CategoryID", "CategoryName");
            ViewBag.Author = new SelectList(DB.Authors, "AuthorID", "AuthorName");
            return View(DB.News.Find(id));
        }
        
        public ActionResult Delete(int id)
        {
            return View(DB.News.Find(id));
        }

        [HttpPost]
        public ActionResult CreateOnSubmit(News news, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string Dir = "/Content/Images/";
                if (Image != null && Image.ContentLength > 0)
                {
                    fileName = Path.GetFileName(Image.FileName);
                    string physicalDir = Server.MapPath(Dir);
                    if(!Directory.Exists(physicalDir))
                    {
                        Directory.CreateDirectory(physicalDir);
                    }
                    string path = Path.Combine(Server.MapPath(Dir), fileName);
                    Image.SaveAs(path);
                    news.Thumbnail = Dir + fileName;
                }
                DB.News.Add(news);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditOnSubmit(News news, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var tin = DB.News.Find(news.NewsID);
                if (tin != null)
                {
                    tin.Title = news.Title;
                    tin.Content = news.Content;
                    string fileName = "";
                    string Dir = "/Content/Images/";
                    if (Image != null && Image.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(Image.FileName);
                        string physicalDir = Server.MapPath(Dir);
                        if (!Directory.Exists(physicalDir))
                        {
                            Directory.CreateDirectory(physicalDir);
                        }
                        string path = Path.Combine(Server.MapPath(Dir), fileName);
                        Image.SaveAs(path);
                        news.Thumbnail = Dir + fileName;
                        tin.Thumbnail = news.Thumbnail;
                    }
                    tin.PublishedDate = news.PublishedDate;
                    tin.CategoryID = news.CategoryID;
                    tin.AuthorID = news.AuthorID;
                    DB.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteOnSubmit(News news)
        {
            if (ModelState.IsValid)
            {
                News found = DB.News.Find(news.NewsID);
                if (found != null)
                {
                    DB.News.Remove(found);
                    DB.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}