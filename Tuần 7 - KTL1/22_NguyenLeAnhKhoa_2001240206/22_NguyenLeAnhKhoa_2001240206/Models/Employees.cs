using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; } 
        public int BirthYear { get; set; }
        public Roles RoleID { get; set; }

        public Employees(int employeeID, string password, string fullName, string gender, int birthYear, Roles roleID)
        {
            EmployeeID = employeeID;
            Password = password;
            FullName = fullName;
            Gender = gender;
            BirthYear = birthYear;
            RoleID = roleID;
        }
    }
}