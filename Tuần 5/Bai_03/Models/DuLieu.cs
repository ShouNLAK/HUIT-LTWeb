using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bai_03.Models
{
    public class DuLieu
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QL_DTDDConnect"].ConnectionString;

        public List<KhachHang> ds_KH = new List<KhachHang>();
        public List<Loai> ds_Loai = new List<Loai>();
        public List<SanPham> ds_SP = new List<SanPham>();
        public List<GioHang> ds_GH = new List<GioHang>();

        public DuLieu()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            getDSKhachHang(connection);
            getDSLoai(connection);
            getDSSanPham(connection);
            getDSGioHang(connection);
        }

        public List<KhachHang> getDSKhachHang(SqlConnection connection)
        {
            String sql = "SELECT * FROM KhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                KhachHang kh = new KhachHang(
                    (int)row["MaKH"],
                    row["HoTen"].ToString(),
                    row["DienThoai"].ToString(),
                    row["GioiTinh"].ToString(),
                    row["SoThich"].ToString(),
                    row["Email"].ToString(),
                    row["MatKhau"].ToString()
                );
                ds_KH.Add(kh);
            }
            return ds_KH;
        }

        public List<Loai> getDSLoai(SqlConnection connection)
        {
            String sql = "SELECT * FROM Loai";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Loai loai = new Loai((int)row["MaLoai"], row["TenLoai"].ToString());
                ds_Loai.Add(loai);
            }
            return ds_Loai;
        }

        public List<SanPham> getDSSanPham(SqlConnection connection)
        {
            String sql = "SELECT * FROM SanPham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Loai loai = ds_Loai.First(x => x.MaLoai == (int)row["MaLoai"]);

                SanPham sp = new SanPham(
                    (int)row["MaSP"],
                    row["TenSP"].ToString(),
                    row["DuongDan"].ToString(),
                    Convert.ToDecimal(row["Gia"]), 
                    row["MoTa"].ToString(),
                    loai
                );
                ds_SP.Add(sp);
            }
            return ds_SP;
        }

        public List<GioHang> getDSGioHang(SqlConnection connection)
        {
            String sql = "SELECT * FROM GioHang";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                KhachHang kh = ds_KH.First(x => x.MaKH == (int)row["MaKH"]);
                SanPham sp = ds_SP.First(x => x.MaSP == (int)row["MaSP"]);

                GioHang gh = new GioHang(
                    (int)row["MaGH"],
                    kh,
                    sp,
                    (int)row["SoLuong"],
                    Convert.ToDateTime(row["Ngay"])
                );
                ds_GH.Add(gh);
            }
            return ds_GH;
        }
    }
}