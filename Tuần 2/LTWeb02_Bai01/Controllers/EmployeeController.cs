using LTWeb02_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai01.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NVList()
        {
            List<Employee> DS = new List<Employee>();
            DS.Add(new Employee(101,"Mr. Trung","140 Lê trọng Tấn", 2000));
            ViewBag.DuLieu = DS;
            return View();
        }
    }
}