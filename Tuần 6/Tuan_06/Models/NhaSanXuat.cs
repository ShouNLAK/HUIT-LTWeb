using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class NhaSanXuat
    {
        public string MaNSX {  get; set; }
        public string TenNSX { get; set; }

        public NhaSanXuat() { }
        public NhaSanXuat(string maNSX, string tenNSX)
        {
            MaNSX = maNSX;
            TenNSX = tenNSX;
        }
    }
}