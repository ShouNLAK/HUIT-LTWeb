using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTTL_2.Models
{
    public class Product
    {
        public  string tenSP { get; set; }
        public string moTa { get; set; }
        public string hinhMinhHoa { get; set; }
        public decimal giaBan { get; set; }


        public Product() { }
        public Product(string tenSP, string moTa, string hinhMinhHoa, decimal giaBan)
        {
            this.tenSP = tenSP;
            this.moTa = moTa;
            this.hinhMinhHoa = hinhMinhHoa;
            this.giaBan = giaBan;
        }
    }
}