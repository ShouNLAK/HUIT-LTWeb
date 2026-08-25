using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai03.Models
{
    public class LoaiSach
    {
        public int MaLoai {  get; set; }
        public string TenLoai { get; set; }

        public LoaiSach(int ma,  string ten)
        {
            MaLoai = ma;
            TenLoai = ten;
        }
    }
}