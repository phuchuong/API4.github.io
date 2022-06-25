using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class SanPham
    {
        public int Id_SP { get; set; } = 0;
        public int MaLoaiSP { get; set; } = 0;
        public int MaThuongHieu { get; set; } = 0;
        public string TenSP { get; set; } = "";
        public int GiaBan { get; set; } = 0;
        public string MoTaChiTiet { get; set; } = "";
        public string KhuyenMai1 { get; set; } = "";
        public string KhuyenMai2 { get; set; } = "";
        public string HinhAnh1 { get; set; } = "";
        public string HinhAnh2 { get; set; } = "";
        public int SoLuong { get; set; } = 0;
        public string type { get; set; } = "";


    }
}
