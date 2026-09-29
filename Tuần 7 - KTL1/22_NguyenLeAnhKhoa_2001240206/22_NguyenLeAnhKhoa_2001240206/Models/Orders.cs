using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Customers CustomerID { get; set; }
        public Employees EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public OrderStatuses StatusID { get; set; }
        public string ShippingAddress { get; set; }
        public bool IsPaid { get; set; }

        public Orders(int orderID, Customers customerID, Employees employeeID, DateTime orderDate, decimal totalAmount, OrderStatuses statusID, string shippingAddress, bool isPaid)
        {
            OrderID = orderID;
            CustomerID = customerID;
            EmployeeID = employeeID;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            StatusID = statusID;
            ShippingAddress = shippingAddress;
            IsPaid = isPaid;
        }
    }
}