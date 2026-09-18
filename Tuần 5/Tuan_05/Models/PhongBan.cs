using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tuan_05.Models
{
    public class PhongBan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PhongBan(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}