using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai01.Models
{
    public class PhongBan
    {
        public int MaPhong {  get; set; }
        public string TenPhong { get; set; }
        
        public PhongBan (int ma, string ten)
        {
            MaPhong = ma;
            TenPhong = ten;
        }
    }
}