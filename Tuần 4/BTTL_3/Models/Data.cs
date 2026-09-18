using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTTL_3.Models
{
    public class Data
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Nước uống" },
                new Category { Id = 2, Name = "Ăn vặt" },
                new Category { Id = 3, Name = "Giải trí" }
            };
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Trà sữa trân châu", Price = 25000, CategoryId = 1, Image = "/Content/img/Tra-sua.jpg" },
                new Product { Id = 2, Name = "Bánh tráng trộn", Price = 20000, CategoryId = 2, Image = "/Content/img/Banh-Trang-Tron.jpg" },
                new Product { Id = 3, Name = "Tô tượng", Price = 35000, CategoryId = 3, Image = "/Content/img/To-tuong.jpg" }
            };
        }
    }
}
