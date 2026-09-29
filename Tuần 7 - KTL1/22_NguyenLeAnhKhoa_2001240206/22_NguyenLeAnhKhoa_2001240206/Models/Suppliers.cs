using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Suppliers
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Suppliers(int supplierID, string supplierName, string address, string phone)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            Address = address;
            Phone = phone;
        }
    }
}