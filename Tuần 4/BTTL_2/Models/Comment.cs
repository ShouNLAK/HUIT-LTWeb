using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTTL_2.Models
{
    public class Comment
    {
        public string tenNguoiDung {  get; set; }
        public string anhDaiDien {  get; set; }
        public DateTime ngayBinhLuan { get; set; }
        public string noiDung {  get; set; }
        public double soSaoDanhGia { get; set; }

        public Comment() { }
        public Comment(string tenNguoiDung, string anhDaiDien, DateTime ngayBinhLuan, string noiDung, double soSaoDanhGia)
        {
            this.tenNguoiDung = tenNguoiDung;
            this.anhDaiDien = anhDaiDien;
            this.ngayBinhLuan = ngayBinhLuan;
            this.noiDung = noiDung;
            this.soSaoDanhGia = soSaoDanhGia;
        }
    }
}