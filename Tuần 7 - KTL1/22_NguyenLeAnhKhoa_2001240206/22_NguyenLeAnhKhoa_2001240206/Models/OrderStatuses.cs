using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class OrderStatuses
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public OrderStatuses(int statusID, string statusName)
        {
            StatusID = statusID;
            StatusName = statusName;
        }
    }
}