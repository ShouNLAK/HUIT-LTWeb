using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai02.Models
{
    public class Sach
    {
        public int MaSach {  get; set; }
        public string TenSach { get; set; }
        public int Gia {  get; set; }
        public string AnhBia { get; set; }
        public string TacGia { get; set; }
        public string MoTa { get; set; }

        public Sach() { }
        public Sach(int ma, string ten, int gia, string url, string tacgia, string mota)
        {
            MaSach = ma;
            TenSach = ten;
            Gia = gia;
            AnhBia = url;
            TacGia = tacgia;
            MoTa = mota;
        }
    }
}