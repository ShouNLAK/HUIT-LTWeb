using System;

namespace LTWeb_Tuan07.Models
{
    public class Tour
    {
        public int MaTour { get; set; }
        public string TenTour { get; set; }
        public DateTime NgayDi { get; set; }
        public decimal GiaVe { get; set; }
        public string NoiKhoiHanh { get; set; }
        public string ChuongTrinhTour { get; set; }
        public string NoiThamQuan { get; set; }
        public DanhMuc MaDM { get; set; }
        public string Hinh { get; set; }
        public string dsHinh { get; set; }
    }
}
