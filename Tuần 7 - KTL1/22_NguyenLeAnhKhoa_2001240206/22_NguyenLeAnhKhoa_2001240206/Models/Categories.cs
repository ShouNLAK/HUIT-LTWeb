using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public Categories(int categoryID, string categoryName, string description)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Description = description;
        }
    }
}