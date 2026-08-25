using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb02_Bai01.Models
{
    public class Khoa
    {
        public string TenKhoa { get; set; }
        public int NamThanhLap { get; set; }
        public string Message { get; set; }

        public Khoa() { }
        public Khoa (string ten, int nam, string mess)
        {
            TenKhoa = ten;
            NamThanhLap = nam;
            Message = mess;
        }
    }
}