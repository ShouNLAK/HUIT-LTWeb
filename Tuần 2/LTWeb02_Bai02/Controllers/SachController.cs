using LTWeb02_Bai02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai02.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach

        public List<Sach> DS = new List<Sach> {
                new Sach (1, "Thiên Sứ Nhà Bên - Tập 5",137500, "https://cdn1.fahasa.com/media/catalog/product/1/7/1785750658154_2451949037403295779_2451949037403295779_0eed3f4f94619e41d19755a147515e46.jpg", "Saekisan", "Nhà xuất bản: Kim Đồng"),
                new Sach (2, "Hikaru - Kì Thủ Cờ Vây - Ultimate Edition - Tập 7", 76000, "https://cdn1.fahasa.com/media/catalog/product/h/i/hikaru_ki-thu-co-vay_ultimate-edition_tap-7_bia_obi_card.jpg", "Yumi Hotta", "Nhà xuất bản: Kim Đồng"),
                new Sach (3, "Mèo Siêu Đỉnh Hôm Nay Lại Buồn Thinh - Tập 4", 28500, "https://cdn1.fahasa.com/media/catalog/product/m/e/meo-sieu-dinh-hom-nay-lai-buon-thinh_tap-4_bia.jpg", "Hitsuzi Yamada",  "Nhà xuất bản: Kim Đồng"),
                new Sach (4, "Black Clover - Tập 34 - Thị Kiến Bóng Đêm", 28500, "https://cdn1.fahasa.com/media/catalog/product/b/l/black-clover_tap-34_bia_postcard.jpg", "Yūki Tabata", "Nhà xuất bản: Kim Đồng"),
                new Sach (5, "Bluelock - Episode Nagi - Tập 4", 33250, "https://cdn1.fahasa.com/media/catalog/product/b/l/bluelock-episode-nagi_tap-4_bia_card-pvc.jpg", "Muneyuki Kaneshiro", "Nhà xuất bản: Kim Đồng"),
                new Sach (6, "Shangri-La Frontier - Thợ Săn Game Rác Khiêu Chiến Game Thần Thánh - Tập 24",38000, "https://cdn1.fahasa.com/media/catalog/product/s/h/shangri-la-frontier_tap-24_bia.jpg", "Katarina, Ryosuke", "Nhà xuất bản: Kim Đồng")
            };

        public ActionResult Index()
        {

            return View(DS);
        }

        public ActionResult ChiTiet(int ID)
        {
            Sach item = DS.Find(X => X.MaSach == ID);
            return View(item);
        }
    }
}