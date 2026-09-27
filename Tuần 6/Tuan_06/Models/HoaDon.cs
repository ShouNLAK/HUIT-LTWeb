using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class HoaDon
    {
        public string MaHoaDon {  get; set; }
        private DateTime ngayTao;
        public DateTime NgayTao
        {
            get { return ngayTao; }
            set
            {
                if (value == null)
                    ngayTao = DateTime.Today;
                else
                    ngayTao = value;
            }
        }
        public KhachHang MaKhachHang { get; set; }

        public HoaDon() { }
        public HoaDon(string maHoaDon, DateTime ngayTao, KhachHang maKhachHang)
        {
            MaHoaDon = maHoaDon;
            NgayTao = ngayTao;
            MaKhachHang = maKhachHang;
        }
    }
}