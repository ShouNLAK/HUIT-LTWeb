using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_03.Models
{
    public class KhachHang
    {
        public int MaKH {  get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string GioiTinh { get; set; }
        public string SoThich { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }

        public KhachHang(int maKH, string hoTen, string dienThoai, string gioiTinh, string soThich, string email, string matKhau)
        {
            MaKH = maKH;
            HoTen = hoTen;
            DienThoai = dienThoai;
            GioiTinh = gioiTinh;
            SoThich = soThich;
            Email = email;
            MatKhau = matKhau;
        }
    }
}