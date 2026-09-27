using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class KhachHang
    {
        public string MaKhachHang {  get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }
        public KhachHang() { }
        public KhachHang(string maKhachHang, string tenKhachHang, string soDienThoai, string matKhau)
        {
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            MatKhau = matKhau;
        }
    }
}