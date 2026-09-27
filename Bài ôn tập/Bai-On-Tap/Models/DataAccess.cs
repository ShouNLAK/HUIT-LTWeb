using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bai_On_Tap.Models
{
    public class DataAccess
    {
        static string connStr = ConfigurationManager.ConnectionStrings["QLHoa"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        public List<SanPham> dsSP = new List<SanPham>();
        public List<DanhMuc> dsDM = new List<DanhMuc>();

        public DataAccess()
        {
            LayDuLieuChung();
        }

        public void LayDuLieuChung()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from SanPham", conn);
            DataTable dtSP = new DataTable();
            da.Fill(dtSP);
            foreach (DataRow dr in dtSP.Rows)
            {
                SanPham sp = new SanPham()
                {
                    MaSP = (int)dr["MaSP"],
                    TenSP = dr["TenSP"].ToString(),
                    Gia = (decimal)dr["Gia"],
                    Hinh = dr["Hinh"].ToString(),
                    MoTa = dr["MoTa"].ToString(),
                    MaDM = (int)dr["MaDM"]
                };
                dsSP.Add(sp);
            }

            SqlDataAdapter daDM = new SqlDataAdapter("Select * from DanhMuc", conn);
            DataTable dtDM = new DataTable();
            daDM.Fill(dtDM);
            foreach (DataRow dr in dtDM.Rows)
            {
                DanhMuc dm = new DanhMuc()
                {
                    MaDM = (int)dr["MaDM"],
                    TenDM = dr["TenDM"].ToString()
                };
                dsDM.Add(dm);
            }
        }
    }
}
