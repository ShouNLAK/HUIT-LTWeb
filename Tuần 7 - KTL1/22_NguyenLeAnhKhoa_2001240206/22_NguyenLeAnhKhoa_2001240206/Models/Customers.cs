using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class Customers
    {
        public int CustomerID {  get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int BirthYear { get; set; }
        public string Avatar { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customers(int customerID, string fullName, string password, string gender, int birthYear, string avatar, string phone, string email, string address)
        {
            CustomerID = customerID;
            FullName = fullName;
            Password = password;
            Gender = gender;
            BirthYear = birthYear;
            Avatar = avatar;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}