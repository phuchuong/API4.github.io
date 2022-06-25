using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API4.Model
{
    public class db
    {
       
        SqlConnection con = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=Doan3_PhucHuong;Integrated Security=True");
        /*        public string LoaiSP(LoaiSP lsp)
                {
                    string msg = string.Empty;
                    try
                    {
                        SqlCommand com = new SqlCommand("LoaiSP", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("MaLoai", lsp.MaLoai);
                        com.Parameters.AddWithValue("Tenloai", lsp.Tenloai);
                        com.Parameters.AddWithValue("type", lsp.type);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        msg = "THANH CONG";


                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                    return msg;
                }
                public DataSet LoaiSPGet(LoaiSP lsp)
                {
                    string msg = string.Empty;
                    DataSet ds = new DataSet();
                    try
                    {
                        SqlCommand com = new SqlCommand("LoaiSP", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("MaLoai", lsp.MaLoai);
                        com.Parameters.AddWithValue("Tenloai", lsp.Tenloai);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        da.Fill(ds);
                        msg = "than cong";



                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                    }

                    return ds;
                }*/
        // loại sp
        public string LoaisanphamOpt(LoaiSP loai)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_LoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaLoaiSP", loai.MaLoaiSP);
                com.Parameters.AddWithValue("TenLoaiSP", loai.TenLoaiSP);
                com.Parameters.AddWithValue("type", loai.type);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet LoaisanphamGet(LoaiSP loai, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_LoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaLoaiSP", loai.MaLoaiSP);
                com.Parameters.AddWithValue("TenLoaiSP", loai.TenLoaiSP);
                com.Parameters.AddWithValue("type", loai.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        // thuong hiẻu
        public string ThuongHieuOpt(ThuongHieu sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_ThuongHieu", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaThuongHieu", sp.MaThuongHieu);
                com.Parameters.AddWithValue("TenThuongHieu", sp.TenThuongHieu);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet ThuongHieuGet(ThuongHieu sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_ThuongHieu", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaThuongHieu", sp.MaThuongHieu);
                com.Parameters.AddWithValue("TenThuongHieu", sp.TenThuongHieu);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //nhaan vien
        public string NhanvienOpt(NhanVien nv)  
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("ADMIN_NhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaNV", nv.MaNV);
                com.Parameters.AddWithValue("TenNV", nv.TenNV);
                com.Parameters.AddWithValue("GioiTinh", nv.GioiTinh);
                com.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                com.Parameters.AddWithValue("DiaChi ", nv.DiaChi);
                com.Parameters.AddWithValue("SDT", nv.SDT);
                com.Parameters.AddWithValue("TrangThai", nv.TrangThai);
                com.Parameters.AddWithValue("taikhoan ", nv.taikhoan);
                com.Parameters.AddWithValue("matkhau", nv.matkhau);
                com.Parameters.AddWithValue("type", nv.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet NhanvienGet(NhanVien nv, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("ADMIN_NhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaNV", nv.MaNV);
                com.Parameters.AddWithValue("TenNV", nv.TenNV);
                com.Parameters.AddWithValue("GioiTinh", nv.GioiTinh);
                com.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                com.Parameters.AddWithValue("DiaChi ", nv.DiaChi);
                com.Parameters.AddWithValue("SDT", nv.SDT);
                com.Parameters.AddWithValue("TrangThai", nv.TrangThai);
                com.Parameters.AddWithValue("taikhoan ", nv.taikhoan);
                com.Parameters.AddWithValue("matkhau", nv.matkhau);
                com.Parameters.AddWithValue("type", nv.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //Sanr pham
        public string SanPhamOpt(SanPham sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_SanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("MaLoaiSP", sp.MaLoaiSP);
                com.Parameters.AddWithValue("MaThuongHieu", sp.MaThuongHieu);
                com.Parameters.AddWithValue("TenSP", sp.TenSP);
                com.Parameters.AddWithValue("GiaBan", sp.GiaBan);
                com.Parameters.AddWithValue("MoTaChiTiet", sp.MoTaChiTiet);
                com.Parameters.AddWithValue("KhuyenMai1", sp.KhuyenMai1);
                com.Parameters.AddWithValue("KhuyenMai2", sp.KhuyenMai2);
                com.Parameters.AddWithValue("HinhAnh1", sp.HinhAnh1);
                com.Parameters.AddWithValue("HinhAnh2", sp.HinhAnh2);
                com.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet SanPhamGet(SanPham sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_SanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("MaLoaiSP", sp.MaLoaiSP);
                com.Parameters.AddWithValue("MaThuongHieu", sp.MaThuongHieu);
                com.Parameters.AddWithValue("TenSP", sp.TenSP);
                com.Parameters.AddWithValue("GiaBan", sp.GiaBan);
                com.Parameters.AddWithValue("MoTaChiTiet", sp.MoTaChiTiet);
                com.Parameters.AddWithValue("KhuyenMai1", sp.KhuyenMai1);
                com.Parameters.AddWithValue("KhuyenMai2", sp.KhuyenMai2);
                com.Parameters.AddWithValue("HinhAnh1", sp.HinhAnh1);
                com.Parameters.AddWithValue("HinhAnh2", sp.HinhAnh2);
                com.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //nhaf cung caasp
        public string NhaCungCapOpt(NhaCungCap sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_NhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaNCC", sp.MaNCC);
                com.Parameters.AddWithValue("TenNCC", sp.TenNCC);
                com.Parameters.AddWithValue("SDT ", sp.SDT);
                com.Parameters.AddWithValue("Email", sp.Email);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet NhaCungCapGet(NhaCungCap sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_NhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaNCC", sp.MaNCC);
                com.Parameters.AddWithValue("TenNCC", sp.TenNCC);
                com.Parameters.AddWithValue("SDT ", sp.SDT);
                com.Parameters.AddWithValue("Email", sp.Email);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //khasch hang
        public string KhachHangOpt(KhachHang sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_KhachHang", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaKH", sp.MaKH);
                com.Parameters.AddWithValue("TenKH", sp.TenKH);
                com.Parameters.AddWithValue("UserName", sp.UserName);
                com.Parameters.AddWithValue("PassWord", sp.PassWord);
                com.Parameters.AddWithValue("DiaChi", sp.DiaChi);
                com.Parameters.AddWithValue("SDT", sp.SDT);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet KhachHangGet(KhachHang sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_KhachHang", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaKH", sp.MaKH);
                com.Parameters.AddWithValue("TenKH", sp.TenKH);
                com.Parameters.AddWithValue("UserName", sp.UserName);
                com.Parameters.AddWithValue("PassWord", sp.PassWord);
                com.Parameters.AddWithValue("DiaChi", sp.DiaChi);
                com.Parameters.AddWithValue("SDT", sp.SDT);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //hoas donw basn
        public string HoaDonBanOpt(HoaDonBan sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_HoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_HDB", sp.Id_HDB);
                com.Parameters.AddWithValue("MaKH", sp.MaKH);
                com.Parameters.AddWithValue("ThanhTien ", sp.ThanhTien);
                com.Parameters.AddWithValue("NgayBan ", sp.NgayBan);
                com.Parameters.AddWithValue("TrangThai ", sp.TrangThai);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet HoaDonBanGet(HoaDonBan sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_HoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_HDB", sp.Id_HDB);
                com.Parameters.AddWithValue("MaKH", sp.MaKH);
                com.Parameters.AddWithValue("ThanhTien ", sp.ThanhTien);
                com.Parameters.AddWithValue("NgayBan ", sp.NgayBan);
                com.Parameters.AddWithValue("TrangThai ", sp.TrangThai);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //chi tieest hoas donw ban
        public string CTHDBOpt(CTHDB sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_CTHDB", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_CTHDB", sp.Id_CTHDB);
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("Id_HDB ", sp.Id_HDB);
                com.Parameters.AddWithValue("SoLuong ", sp.SoLuong);
                com.Parameters.AddWithValue("DonGia  ", sp.DonGia);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet CTHDBGet(CTHDB sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_CTHDB", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_CTHDB", sp.Id_CTHDB);
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("Id_HDB ", sp.Id_HDB);
                com.Parameters.AddWithValue("SoLuong ", sp.SoLuong);
                com.Parameters.AddWithValue("DonGia  ", sp.DonGia);
                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        // hoas don nhap
        public string HoaDonNhapOpt(HoaDonNhap sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_HoaDonNhap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ID_HDN", sp.Id_HDN);
                com.Parameters.AddWithValue("MaNCC", sp.MaNCC);
                com.Parameters.AddWithValue("NgayNhap ", sp.NgayNhap);
                com.Parameters.AddWithValue("TongTien ", sp.TongTien);
         
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet HoaDonNhapGet(HoaDonNhap sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_HoaDonNhap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("ID_HDN", sp.Id_HDN);
                com.Parameters.AddWithValue("MaNCC", sp.MaNCC);
                com.Parameters.AddWithValue("NgayNhap ", sp.NgayNhap);
                com.Parameters.AddWithValue("TongTien ", sp.TongTien);

                com.Parameters.AddWithValue("type", sp.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        // chi tieets hoa don nhap
        public string CTHDNOpt(CTHDN sp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_CTHDN", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_CTHDN", sp.Id_CTHDN);
                com.Parameters.AddWithValue("Id_HDN", sp.Id_HDN);
                com.Parameters.AddWithValue("MaNV", sp.MaNV);
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                com.Parameters.AddWithValue("type", sp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet CTHDNGet(CTHDN sp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_CTHDN", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id_CTHDN", sp.Id_CTHDN);
                com.Parameters.AddWithValue("Id_HDN", sp.Id_HDN);
                com.Parameters.AddWithValue("MaNV", sp.MaNV);
                com.Parameters.AddWithValue("Id_SP", sp.Id_SP);
                com.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                com.Parameters.AddWithValue("type", sp.type);
           
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
