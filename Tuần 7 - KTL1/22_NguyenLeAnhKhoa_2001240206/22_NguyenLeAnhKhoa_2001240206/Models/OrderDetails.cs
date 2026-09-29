using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class OrderDetails
    {
        public Orders OrderID { get; set; }
        public Products ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Colors ColorID {  get; set; }
        public Diopters DiopterID { get; set; }

        public OrderDetails(Orders orderID, Products productID, int quantity, decimal unitPrice, Colors colorID, Diopters diopterID)
        {
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            UnitPrice = unitPrice;
            ColorID = colorID;
            DiopterID = diopterID;
        }
    }
}