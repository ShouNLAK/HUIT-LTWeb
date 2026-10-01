using System;

namespace LTWeb_Tuan07.Models
{
    public class DatHang
    {
        public int MaDH { get; set; }
        public KhachHang MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
