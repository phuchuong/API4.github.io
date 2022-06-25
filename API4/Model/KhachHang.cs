using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class KhachHang
    {
        public int MaKH { get; set; } = 0;
        public string TenKH{ get; set; } = "";
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public int SDT { get; set; } = 0;
        public string type { get; set; } = "";

    }
}
