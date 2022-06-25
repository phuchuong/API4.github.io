using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class HoaDonNhap
    {
        public int Id_HDN { get; set; } = 0;
        public int MaNCC { get; set; } = 0;
        public string NgayNhap { get; set; } = "";
        public int TongTien { get; set; } = 0;
        public string type { get; set; } = "";

    }
}
