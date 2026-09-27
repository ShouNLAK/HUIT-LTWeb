using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tuan_06.Models
{
    public class DuLieu
    {
        static string connection = ConfigurationManager.ConnectionStrings["QL_Sach"].ConnectionString;
        SqlConnection SQL = new SqlConnection(connection);
        public List<NhaSanXuat> listNSX = new List<NhaSanXuat>();
        public List<Loai> listLoai = new List<Loai>();
        public List<KhachHang> listKH = new List<KhachHang>();
        public List<SanPham> listSP = new List<SanPham>();
        public List<HoaDon> listHD = new List<HoaDon>();
        public List<ChiTiet> listCT = new List<ChiTiet>();

        public DuLieu()
        {
            GetNSX();
            GetLoai();
            GetKH();
            GetSP();
            GetHD();
            GetCT();
        }

        public void GetNSX()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_NhaSanXuat",SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows) 
            {
                listNSX.Add(
                    new NhaSanXuat(
                        row["MaNSX"].ToString(),
                        row["TenNSX"].ToString()
                        )
                    );
            }
        }

        public void GetLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Loai", SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows)
            {
                listLoai.Add(
                    new Loai(
                        row["MaLoai"].ToString(),
                        row["TenLoai"].ToString()
                        )
                    );
            }
        }

        public void GetKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_KhachHang", SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows)
            {
                listKH.Add(
                    new KhachHang(
                        row["MaKhachHang"].ToString(),
                        row["TenKhachHang"].ToString(),
                        row["SoDienThoai"].ToString(),
                        row["MatKhau"].ToString()
                        )
                    );
            }
        }
        public void GetSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_SanPham", SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows)
            {
                listSP.Add(
                    new SanPham(
                        row["MaSanPham"].ToString(),
                        row["TenSP"].ToString(),
                        listLoai.First(x => x.MaLoai == row["MaL"].ToString()),
                        listNSX.First(x => x.MaNSX == row["MaSX"].ToString()),
                        (decimal)row["Gia"],
                        row["GhiChu"].ToString(),
                        row["Hinh"].ToString()
                        )
                    );
            }
        }
        public void GetHD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_HoaDon", SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows)
            {
                listHD.Add(
                    new HoaDon(
                        row["MaHoaDon"].ToString(),
                        ((DateTime)row["NgayTao"]).Date,
                        listKH.First(x => x.MaKhachHang == row["MaKH"].ToString())
                        )
                    );
            }
        }
        public void GetCT()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_ChiTiet", SQL);
            DataTable db = new DataTable();
            da.Fill(db);
            foreach (DataRow row in db.Rows)
            {
                listCT.Add(
                    new ChiTiet(
                        listHD.First(x => x.MaHoaDon == row["MaHD"].ToString()),
                        listSP.First(x => x.MaSP == row["MaSP"].ToString()),
                        (int)row["SoLuong"]
                        )
                    );
            }
        }
    }
}