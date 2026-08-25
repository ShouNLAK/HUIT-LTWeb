using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTWeb03_Bai04.Models
{
    public class Infomation
    {
        [Required(ErrorMessage ="Tên không được để trống")]
        public string FullName { get; set; }
        [StringLength(10,ErrorMessage ="Vui lòng nhập đủ 10 số",MinimumLength =10)]
        public string IdStudent { get; set; }
        public string Email { get; set; }
        public string FileImage { get; set; }
        public string Note { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public bool Check3 { get; set; }
        public string ChooseWorkTime { get; set; }
        public string SelectCourse { get; set; }
    }
}