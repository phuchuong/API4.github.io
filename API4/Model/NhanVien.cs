using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class NhanVien
    {
        public int MaNV { get; set; } = 0;
        public string TenNV { get; set; } = "";
        public string GioiTinh { get; set; } = "";
        public string NgaySinh { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public int SDT { get; set; } = 0;
        public int TrangThai { get; set; } = 0;
        public string taikhoan { get; set; } = "";
        public string matkhau { get; set; } = "";
        public string type { get; set; } = "";
    }
}
