using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class HoaDonBan
    {
        public int Id_HDB { get; set; } = 0;
        public int MaKH { get; set; } = 0;
        public int ThanhTien { get; set; } = 0;
        public string NgayBan { get; set; } = "";
        public int TrangThai { get; set; } = 0;
        public string type { get; set; } = "";
    }
}
