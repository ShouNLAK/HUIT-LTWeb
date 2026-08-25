using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai04.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        
        public string Code { get; set; }
        public string Length { get; set; }
        public string OuterDiameter { get; set; }
        public string Thickness { get; set; }
        public string BaseLength { get; set; }
        public string Standard { get; set; }
        public string Alloy { get; set; }
    }
}
