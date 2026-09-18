using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_03.Models
{
    public class GioHang
    {
        public int MaGH {  get; set; }
        public KhachHang MaKH {  get; set; }
        public SanPham MaSP { get; set; }
        public int SoLuong { get; set; }
        public DateTime Ngay {  get; set; }

        public GioHang(int maGH, KhachHang maKH, SanPham maSP, int soLuong, DateTime ngay)
        {
            MaGH = maGH;
            MaKH = maKH;
            MaSP = maSP;
            SoLuong = soLuong;
            Ngay = ngay;
        }
    }
}