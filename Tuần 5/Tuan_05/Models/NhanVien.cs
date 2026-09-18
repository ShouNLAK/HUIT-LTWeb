using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_05.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public PhongBan P_ID { get; set; }

        public NhanVien(int id, string name, string gender, string city, PhongBan p_ID)
        {
            Id = id;
            Name = name;
            Gender = gender;
            City = city;
            P_ID = p_ID;
        }
    }
}