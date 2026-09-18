using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tuan_05.Models
{
    public class DuLieu
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QL_NhanSuConnect"].ConnectionString;
        public List<PhongBan> ds_PB = new List<PhongBan>();
        public List<NhanVien> ds_NV = new List<NhanVien>();
        public DuLieu()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            getDSPB(connection);
            getDSNV(connection);
        }

        public List<PhongBan> getDSPB(SqlConnection connection)
        {
            String getDSPB = "SELECT * FROM tblDepartment";
            SqlDataAdapter connect_PB = new SqlDataAdapter(getDSPB, connection);
            DataTable dataTable_PB = new DataTable();
            connect_PB.Fill(dataTable_PB);
            foreach (DataRow row in dataTable_PB.Rows)
            {
                PhongBan pb = new PhongBan((int)row["Deptid"], row["Name"].ToString());
                ds_PB.Add(pb);
            }
            return ds_PB;
        }

        public List<NhanVien> getDSNV (SqlConnection connection)
        {
            String getDSNV = "SELECT * FROM tblEmployee";
            SqlDataAdapter connect_NV = new SqlDataAdapter(getDSNV, connection);

            DataTable dataTable_NV = new DataTable();
            connect_NV.Fill(dataTable_NV);

            foreach (DataRow row in dataTable_NV.Rows)
            {
                NhanVien nv = new NhanVien((int)row["Id"], row["Name"].ToString(),
                    row["Gender"].ToString(), row["City"].ToString(), ds_PB.First(x => x.Id == (int)row["Deptid"]));
                ds_NV.Add(nv);
            }
            return ds_NV;
        }
    }
}