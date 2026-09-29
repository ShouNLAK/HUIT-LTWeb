using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public Roles(int roleID, string roleName, string description)
        {
            RoleID = roleID;
            RoleName = roleName;
            Description = description;
        }
    }
}