using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ManufactureYear { get; set; }
        public int StockQuantity { get; set; }
        public Decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Avatar {  get; set; }
        public Categories CategoryID { get; set; }
        public Suppliers SupplierID { get; set; }

        public Products(int productID, string productName, int manufactureYear, int stockQuantity, decimal price, string shortDescription, string avatar, Categories categoryID, Suppliers supplierID)
        {
            ProductID = productID;
            ProductName = productName;
            ManufactureYear = manufactureYear;
            StockQuantity = stockQuantity;
            Price = price;
            ShortDescription = shortDescription;
            Avatar = avatar;
            CategoryID = categoryID;
            SupplierID = supplierID;
        }
    }
}