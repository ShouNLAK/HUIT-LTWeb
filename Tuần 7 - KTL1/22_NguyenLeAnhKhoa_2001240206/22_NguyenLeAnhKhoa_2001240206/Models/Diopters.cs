using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Diopters
    {
        public int DiopterID { get; set; }
        public Decimal DiopterValue { get; set; }
        public string Description { get; set; }

        public Diopters(int diopterID, decimal diopterValue, string description)
        {
            DiopterID = diopterID;
            DiopterValue = diopterValue;
            Description = description;
        }
    }
}