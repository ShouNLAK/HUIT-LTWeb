using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai03.Models
{
    public class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int Gia { get; set; }
        public string HinhAnh { get; set; }
        public LoaiSach Loai { get; set; }

        public Sach(int id, string ten, int gia, string url, LoaiSach loai)
        {
            MaSach = id;
            TenSach = ten;
            Gia = gia;
            HinhAnh = url;
            Loai = loai;
        }
    }

}