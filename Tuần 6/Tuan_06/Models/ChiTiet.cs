using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class ChiTiet
    {
        public HoaDon MaHoaDon { get; set; }
        public SanPham MaSanPham {  get; set; }
        public int SoLuong { get; set; }

        public ChiTiet() { }
        public ChiTiet(HoaDon maHoaDon, SanPham maSanPham, int soLuong)
        {
            MaHoaDon = maHoaDon;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
        }
    }
}