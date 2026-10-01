using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LTWeb_Tuan07.Models
{
    public class DataSQL
    {
        static string connStr = ConfigurationManager.ConnectionStrings["QLTour"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);

        public List<KhachHang> DS_KhachHang = new List<KhachHang>();
        public List<DanhMuc> DS_DanhMuc = new List<DanhMuc>();
        public List<DichVu> DS_DichVu = new List<DichVu>();
        public List<Tour> DS_Tour = new List<Tour>();
        public List<DatHang> DS_DatHang = new List<DatHang>();
        public List<ChiTietDatHang> DS_ChiTietDatHang = new List<ChiTietDatHang>();
        public List<ChiTietTour> DS_ChiTietTour = new List<ChiTietTour>();

        public DataSQL()
        {
            GetKhachHang();
            GetDanhMuc();
            GetDichVu();
            GetTour();
            GetDatHang();
            GetChiTietDatHang();
            GetChiTietTour();
        }

        public void GetKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_KhachHang.Add(new KhachHang()
                {
                    MaKH = (int)row["MaKH"],
                    TenKH = row["TenKH"].ToString(),
                    SoDT = row["SoDT"].ToString(),
                    MatKhau = row["MatKhau"].ToString()
                });
            }
        }

        public void GetDanhMuc()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DanhMuc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_DanhMuc.Add(new DanhMuc()
                {
                    MaDM = (int)row["MaDM"],
                    TenDM = row["TenDM"].ToString()
                });
            }
        }

        public void GetDichVu()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DichVu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_DichVu.Add(new DichVu()
                {
                    MaDV = (int)row["MaDV"],
                    TenDichVu = row["TenDichVu"].ToString()
                });
            }
        }

        public void GetTour()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tour", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_Tour.Add(new Tour()
                {
                    MaTour = (int)row["MaTour"],
                    TenTour = row["TenTour"].ToString(),
                    NgayDi = (DateTime)row["NgayDi"],
                    GiaVe = (decimal)row["GiaVe"],
                    NoiKhoiHanh = row["NoiKhoiHanh"].ToString(),
                    ChuongTrinhTour = row["ChuongTrinhTour"].ToString(),
                    NoiThamQuan = row["NoiThamQuan"].ToString(),
                    MaDM = DS_DanhMuc.FirstOrDefault(x => x.MaDM == (int)row["MaDM"]),
                    Hinh = row["Hinh"].ToString(),
                    dsHinh = row["dsHinh"].ToString()
                });
            }
        }

        public void GetDatHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DatHang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_DatHang.Add(new DatHang()
                {
                    MaDH = (int)row["MaDH"],
                    MaKH = DS_KhachHang.FirstOrDefault(x => x.MaKH == (int)row["MaKH"]),
                    NgayDat = row["NgayDat"] != DBNull.Value ? (DateTime)row["NgayDat"] : DateTime.Now,
                    TinhTrang = row["TinhTrang"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                });
            }
        }

        public void GetChiTietDatHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ChiTietDatHang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_ChiTietDatHang.Add(new ChiTietDatHang()
                {
                    MaDH = DS_DatHang.FirstOrDefault(x => x.MaDH == (int)row["MaDH"]),
                    MaTour = DS_Tour.FirstOrDefault(x => x.MaTour == (int)row["MaTour"]),
                    SoLuong = row["SoLuong"] != DBNull.Value ? (int)row["SoLuong"] : 0
                });
            }
        }

        public void GetChiTietTour()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ChiTietTour", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                DS_ChiTietTour.Add(new ChiTietTour()
                {
                    MaDV = DS_DichVu.FirstOrDefault(x => x.MaDV == (int)row["MaDV"]),
                    MaTour = DS_Tour.FirstOrDefault(x => x.MaTour == (int)row["MaTour"])
                });
            }
        }
    }
}
