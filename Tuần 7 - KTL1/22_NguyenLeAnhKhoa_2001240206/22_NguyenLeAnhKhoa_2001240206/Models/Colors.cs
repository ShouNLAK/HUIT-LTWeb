using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Colors
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }

        public Colors(int colorID, string colorName, string hexCode)
        {
            ColorID = colorID;
            ColorName = colorName;
            HexCode = hexCode;
        }
    }
}