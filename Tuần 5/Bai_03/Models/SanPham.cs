using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_03.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DuongDan {  get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public Loai MaLoai { get; set; }

        public SanPham(int maSP, string tenSP, string duongDan, decimal gia, string moTa, Loai maLoai)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DuongDan = duongDan;
            Gia = gia;
            MoTa = moTa;
            MaLoai = maLoai;
        }
    }
}