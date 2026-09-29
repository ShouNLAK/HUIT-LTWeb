using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace _22_NguyenLeAnhKhoa_2001240206.Models
{
    public class DataSQL
    {
        static string connStr = ConfigurationManager.ConnectionStrings["QLBanMatKinh"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);

        public List<Suppliers> DS_NhaCungCap = new List<Suppliers>();
        public List<Categories> DS_DanhMuc = new List<Categories>();
        public List<Products> DS_SanPham = new List<Products>();
        public List<ProductImages> DS_Anh_SanPham = new List<ProductImages>();
        public List<Customers> DS_KhachHang = new List<Customers>();
        public List<Roles> DS_VaiTro = new List<Roles>();
        public List<Employees> DS_NhanVien = new List<Employees>();
        public List<OrderStatuses> DS_TrangThai_DonHang = new List<OrderStatuses>();
        public List<Colors> DS_MauKinh = new List<Colors>();
        public List<Diopters> DS_DoCan = new List<Diopters>();
        public List<Orders> DS_DonHang = new List<Orders>();
        public List<OrderDetails> DS_ChiTiet_DonHang = new List<OrderDetails>();

        public DataSQL()
        {
            GetNCC();
            GetDM();
            GetSP();
            GetASP();
            GetKH();
            GetVT();
            GetNV();
            GetOS();
            GetMau();
            GetCKX();
            GetDH();
            GetCTDH();
        }


        public void GetNCC()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Suppliers", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Suppliers value = new Suppliers(
                    (int)dr["SupplierID"],
                    dr["SupplierName"].ToString(),
                    dr["Address"].ToString(),
                    dr["Phone"].ToString()
                    );
                DS_NhaCungCap.Add(value);
            }
        }

        public void GetDM()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Categories", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Categories value = new Categories(
                    (int)dr["CategoryID"],
                    dr["CategoryName"].ToString(),
                    dr["Description"].ToString()
                    );
                DS_DanhMuc.Add(value);
            }
        }

        public void GetSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Products", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Products value = new Products(
                    (int)dr["ProductID"],
                    dr["ProductName"].ToString(),
                    (int)dr["ManufactureYear"],
                    (int)dr["StockQuantity"],
                    (decimal)dr["Price"],
                    dr["ShortDescription"].ToString(),
                    dr["Avatar"].ToString(),
                    DS_DanhMuc.First(x => x.CategoryID == (int)dr["CategoryID"]),
                    DS_NhaCungCap.First(x => x.SupplierID == (int)dr["SupplierID"])
                    );
                DS_SanPham.Add(value);
            }
        }

        public void GetASP()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from ProductImages", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ProductImages value = new ProductImages(
                    (int)dr["ImageID"],
                    DS_SanPham.First(x => x.ProductID == (int)dr["ProductID"]),
                    dr["ImageName"].ToString()
                    );
                DS_Anh_SanPham.Add(value);
            }
        }

        public void GetKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Customers", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Customers value = new Customers(
                    (int)dr["CustomerID"],
                    dr["FullName"].ToString(),
                    dr["Password"].ToString(),
                    dr["Gender"].ToString(),
                    (int)dr["BirthYear"],
                    dr["Avatar"].ToString(),
                    dr["Phone"].ToString(),
                    dr["Email"].ToString(),
                    dr["Address"].ToString()
                    );
                DS_KhachHang.Add(value);
            }
        }

        public void GetVT()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Roles", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Roles value = new Roles(
                    (int)dr["RoleID"],
                    dr["RoleName"].ToString(),
                    dr["Description"].ToString()
                    );
                DS_VaiTro.Add(value);
            }
        }

        public void GetNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Employees value = new Employees(
                    (int)dr["EmployeeID"],
                    dr["Password"].ToString(),
                    dr["FullName"].ToString(),
                    dr["Gender"].ToString(),
                    (int)dr["BirthYear"],
                    DS_VaiTro.First(x => x.RoleID == (int)dr["RoleID"])
                    );
                DS_NhanVien.Add(value);
            }
        }

        public void GetOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from OrderStatuses", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                OrderStatuses value = new OrderStatuses(
                    (int)dr["StatusID"],
                    dr["StatusName"].ToString()
                    );
                DS_TrangThai_DonHang.Add(value);
            }
        }

        public void GetMau()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Colors", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Colors value = new Colors(
                    (int)dr["ColorID"],
                    dr["ColorName"].ToString(),
                    dr["HexCode"].ToString()
                    );
                DS_MauKinh.Add(value);
            }
        }

        public void GetCKX()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Diopters", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Diopters value = new Diopters(
                    (int)dr["DiopterID"],
                    (Decimal)dr["DiopterValue"],
                    dr["Description"].ToString()
                    );
                DS_DoCan.Add(value);
            }
        }

        public void GetDH()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Orders", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Orders value = new Orders(
                    (int)dr["OrderID"],
                    DS_KhachHang.First(x => x.CustomerID == (int)dr["CustomerID"]),
                    DS_NhanVien.First(x => x.EmployeeID == (int)dr["EmployeeID"]),
                    (DateTime)dr["OrderDate"],
                    (Decimal)dr["TotalAmount"],
                    DS_TrangThai_DonHang.First(x => x.StatusID == (int)dr["StatusID"]),
                    dr["ShippingAddress"].ToString(),
                    (bool)dr["IsPaid"]
                    );
                DS_DonHang.Add(value);
            }
        }

        public void GetCTDH()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from OrderDetails", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (DS_SanPham.Any(x => x.ProductID == (int)dr["ProductID"] && x.CategoryID.CategoryID == 1))
                {
                    OrderDetails value = new OrderDetails(
                    DS_DonHang.First(x => x.OrderID == (int)dr["OrderID"]),
                    DS_SanPham.First(x=> x.ProductID == (int)dr["ProductID"]),
                    (int)dr["Quantity"],
                    (Decimal)dr["UnitPrice"],
                    DS_MauKinh.First(x => x.ColorID == (int)dr["ColorID"]),
                    DS_DoCan.First(x => x.DiopterID == (int)dr["DiopterID"])
                    );
                    DS_ChiTiet_DonHang.Add(value);
                }
                if (DS_SanPham.Any(x => x.ProductID == (int)dr["ProductID"] && x.CategoryID.CategoryID == 2))
                {
                    OrderDetails value = new OrderDetails(
                        DS_DonHang.First(x => x.OrderID == (int)dr["OrderID"]),
                        DS_SanPham.First(x => x.ProductID == (int)dr["ProductID"]),
                        (int)dr["Quantity"],
                        (Decimal)dr["UnitPrice"],
                        DS_MauKinh.First(x => x.ColorID == (int)dr["ColorID"]),
                        null
                        );
                    DS_ChiTiet_DonHang.Add(value);
                }
                else
                {
                    OrderDetails value = new OrderDetails(
                    DS_DonHang.First(x => x.OrderID == (int)dr["OrderID"]),
                    DS_SanPham.First(x => x.ProductID == (int)dr["ProductID"]),
                    (int)dr["Quantity"],
                    (Decimal)dr["UnitPrice"],
                    null,
                    DS_DoCan.First(x => x.DiopterID == (int)dr["DiopterID"])
                    );
                    DS_ChiTiet_DonHang.Add(value);
                }
            }
        }
    }
}