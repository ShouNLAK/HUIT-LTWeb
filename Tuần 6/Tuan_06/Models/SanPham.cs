using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public Loai MaLoai { get; set; }
        public NhaSanXuat MaNSX {  get; set; }
        public decimal Gia { get; set; }
        public string GhiChu { get; set; }
        public string Hinh {  get; set; }
        public SanPham() { }
        public SanPham(string maSP, string tenSP, Loai maLoai, NhaSanXuat maNSX, decimal gia, string ghiChu, string hinh)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MaLoai = maLoai;
            MaNSX = maNSX;
            Gia = gia;
            GhiChu = ghiChu;
            Hinh = hinh;
        }
    }
}