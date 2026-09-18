using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTTL_2.Models
{
    public class Feedback
    {
        public int tongSoLuong { get; set; }
        public double diemTB { get; set; }
        public int[] slDanhGiaTheosao;
        public List<Comment> dsComment;

        public Feedback() { }
        public Feedback(int tongSoLuong, double diemTB, int[] slDanhGiaTheosao, List<Comment> dsComment)
        {
            this.tongSoLuong = tongSoLuong;
            this.diemTB = diemTB;
            this.slDanhGiaTheosao = slDanhGiaTheosao;
            this.dsComment = dsComment;
        }
    }
}