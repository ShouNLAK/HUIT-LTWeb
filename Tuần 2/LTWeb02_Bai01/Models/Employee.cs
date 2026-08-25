using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai01.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }

        public Employee() { }
        public Employee(int id ,  string name , string address , int salary)
        {
            ID = id;
            Name = name;
            Address = address;
            Salary = salary;
        }
    }
}