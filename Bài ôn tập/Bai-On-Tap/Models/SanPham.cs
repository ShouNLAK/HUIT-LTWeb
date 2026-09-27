using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_On_Tap.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal Gia { get; set; }
        public string Hinh { get; set; }
        public string MoTa { get; set; }
        public int MaDM { get; set; }
    }
}
