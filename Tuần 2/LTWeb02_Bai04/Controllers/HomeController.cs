using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb02_Bai04.Models;

namespace LTWeb02_Bai04.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = "1", Name = "ỐNG ĐỒNG LUVATA DẠNG CUỘN", Description = "Ống đồng Luvata dạng cuộn chất lượng cao dành cho ngành công nghiệp", ImageUrl = "/Content/IMG/Luvata.jpg", Price = "Liên Hệ", Code = "SP001", Length = "15.88 m", OuterDiameter = "4.76mm - 28.58mm", Thickness = "0.41mm - 1.27mm", BaseLength = "15m - 50m", Standard = "ASTM B-280, EN-12735, JISH-3300", Alloy = "C12200, C1220, TP2" },
                new Product { Id = "2", Name = "ỐNG ĐỒNG LUVATA DẠNG BÀNH", Description = "Ống đồng Luvata dạng bành được sử dụng nhiều trong việc lắp đặt", ImageUrl = "/Content/IMG/Luvata.jpg", Price = "Liên Hệ", Code = "SP002", Length = "15.88 m", OuterDiameter = "4.76mm - 28.58mm", Thickness = "0.41mm - 1.27mm", BaseLength = "15m - 50m", Standard = "ASTM B-280, EN-12735, JISH-3300", Alloy = "C12200, C1220, TP2" },
                new Product { Id = "3", Name = "ỐNG ĐỒNG METTUBE DẠNG CUỘN", Description = "Ống đồng Mettube dạng cuộn sử dụng trong máy lạnh đạt tiêu chuẩn", ImageUrl = "/Content/IMG/Mettube.jpg", Price = "Liên Hệ", Code = "SP003", Length = "15.88 m", OuterDiameter = "4.76mm - 28.58mm", Thickness = "0.41mm - 1.27mm", BaseLength = "15m - 50m", Standard = "ASTM B-280, EN-12735, JISH-3300", Alloy = "C12200, C1220, TP2" },
                new Product { Id = "4", Name = "ỐNG ĐỒNG THÁI LAN", Description = "Ống đồng Thái Lan chất lượng cực tốt", ImageUrl = "/Content/IMG/Thailand.jpg", Price = "Liên Hệ", Code = "SP004", Length = "15.88 m", OuterDiameter = "4.76mm - 28.58mm", Thickness = "0.41mm - 1.27mm", BaseLength = "15m - 50m", Standard = "ASTM B-280, EN-12735", Alloy = "C12200, C1220" },
                new Product { Id = "5", Name = "ỐNG ĐỒNG CRANE COPPER TUBE", Description = "Ống đồng Crane Copper Tube chính hãng", ImageUrl = "/Content/IMG/Crane-copper-tune.jpg", Price = "Liên Hệ", Code = "SP005", Length = "15.88 m", OuterDiameter = "4.76mm - 28.58mm", Thickness = "0.41mm - 1.27mm", BaseLength = "15m - 50m", Standard = "ASTM B-280, JISH-3300", Alloy = "C12200, TP2" }
            };
        }

        public ActionResult Index()
        {
            var products = GetProducts().Take(3).ToList();
            return View(products);
        }

        public ActionResult Detail(string id)
        {
            var allProducts = GetProducts();
            var product = allProducts.FirstOrDefault(p => p.Id == id);
            
            if (product == null)
            {
                return HttpNotFound();
            }
            
            var relatedProducts = allProducts.Where(p => p.Id != id).Take(3).ToList();
            ViewBag.RelatedProducts = relatedProducts;
            
            return View(product);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
