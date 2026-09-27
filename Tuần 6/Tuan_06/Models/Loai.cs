using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class Loai
    {
        public string MaLoai {  get; set; }
        public string TenLoai { get; set; }

        public Loai() { }
        public Loai(string maLoai, string tenLoai)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
        }
    }
}