using BTTL_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTTL_2.Controllers
{
    public class ProductController : Controller
    {
        public Product SP = new Product("DRY-EX Áo Hoodie Chống Tia UV Kéo Khóa", "Unisex,\r\n\r\nMàu sắc, hoa văn mới,\r\n\r\nSản phẩm được làm từ chất liệu tái chế", "/Content/img/SP_1.jpg", 588000);
        public List<Comment> DS_CM = new List<Comment> {
            new Comment("Nguyễn Văn A", "/Content/img/Ava.jpg", new DateTime(2025,07,13), "Sản phẩm rất chất lượng, giao hàng nhanh. Rất hài lòng", 5),
            new Comment("Trần Thị B", "/Content/img/Ava.jpg", new DateTime(2025,07,12), "Màu sắc đẹp, đúng nhưu hình. Giá cả hợp lý", 4),
            new Comment("Lê Quốc C", "/Content/img/Ava.jpg", new DateTime(2025,07,11), "Đóng gói kỹ, tuy nhiên giao hơi chậm. Sản phẩm ổn", 3)
        };
        public Feedback DS_FB;
        public ProductController()
        {
            DS_FB = new Feedback
            {
                tongSoLuong = DS_CM.Count,
                diemTB = DS_CM.Any() ? DS_CM.Average(c => c.soSaoDanhGia) : 0,
                slDanhGiaTheosao = new int[]
                {
                    DS_CM.Count(c => (int)Math.Round(c.soSaoDanhGia) == 1),
                    DS_CM.Count(c => (int)Math.Round(c.soSaoDanhGia) == 2),
                    DS_CM.Count(c => (int)Math.Round(c.soSaoDanhGia) == 3),
                    DS_CM.Count(c => (int)Math.Round(c.soSaoDanhGia) == 4),
                    DS_CM.Count(c => (int)Math.Round(c.soSaoDanhGia) == 5)
                },
                dsComment = DS_CM
            };
        }

        public ActionResult _showComment()
        {
            return PartialView(DS_CM);
        }

        public ActionResult _showStar()
        {
            return PartialView(DS_FB);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(SP);
        }
    }
}