using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTWeb03_Bai05.Models
{
    public class Sach
    {
        // Explicit parameterless constructor để MVC model binder có thể tạo instance
        public Sach() { }

        [Required(ErrorMessage ="Vui lòng nhập mã sách")]
        public string maSach {  get; set; }
        [Required(ErrorMessage="Vui lòng nhập tên sách")]
        public string tenSach { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập giá tiền")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal? gia { get; set; }
        public string anhBia { get; set; }

        public Sach(string ma, string ten, decimal giaSach, string anh)
        {
            maSach = ma;
            tenSach = ten;
            gia = giaSach;
            anhBia = anh;
        }
        
    }
}