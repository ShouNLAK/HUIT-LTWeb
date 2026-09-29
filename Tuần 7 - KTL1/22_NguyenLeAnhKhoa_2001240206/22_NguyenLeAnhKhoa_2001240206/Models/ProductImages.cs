using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class ProductImages
    {
        public int ImageID { get; set; }
        public Products ProductID { get; set; }
        public string ImageName { get; set; }

        public ProductImages(int imageID, Products productID, string imageName)
        {
            ImageID = imageID;
            ProductID = productID;
            ImageName = imageName;
        }
    }
}