using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API4.Model;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetSanPham")]

        public List<SanPham> Get()
        {
            SanPham sp = new SanPham();
            sp.type = "get";
            DataSet ds = dbconnect.SanPhamGet(sp, out msg);
            List<SanPham> list = new List<SanPham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SanPham
                {
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    MaLoaiSP = Convert.ToInt32(dr["MaLoaiSP"]),
                    MaThuongHieu = Convert.ToInt32(dr["MaThuongHieu"]),
                    TenSP = dr["TenSP"].ToString(),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    MoTaChiTiet = dr["MoTaChiTiet"].ToString(),
                    KhuyenMai1 = dr["KhuyenMai1"].ToString(),
                    KhuyenMai2 = dr["KhuyenMai2"].ToString(),
                    HinhAnh1 = dr["HinhAnh1"].ToString(),
                    HinhAnh2 = dr["HinhAnh2"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                }
                );
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<SanPham> Get(int id)
        {
            SanPham sp = new SanPham();
            sp.Id_SP = id;
            sp.type = "getid";
            DataSet ds = dbconnect.SanPhamGet(sp, out msg);
            List<SanPham> list = new List<SanPham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SanPham
                {
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    MaLoaiSP = Convert.ToInt32(dr["MaLoaiSP"]),
                    MaThuongHieu = Convert.ToInt32(dr["MaThuongHieu"]),
                    TenSP = dr["TenSP"].ToString(),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    MoTaChiTiet = dr["MoTaChiTiet"].ToString(),
                    KhuyenMai1 = dr["KhuyenMai1"].ToString(),
                    KhuyenMai2 = dr["KhuyenMai2"].ToString(),
                    HinhAnh1 = dr["HinhAnh1"].ToString(),
                    HinhAnh2 = dr["HinhAnh2"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),

                });
            }
            return list;
        }

        [HttpGet("loaisp/{id}")]
        public List<SanPham> Getlsp(int id)
        {
            SanPham sp = new SanPham();
            sp.MaLoaiSP = id;
            sp.type = "getloai";
            DataSet ds = dbconnect.SanPhamGet(sp, out msg);
            List<SanPham> list = new List<SanPham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SanPham
                {
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    MaLoaiSP = Convert.ToInt32(dr["MaLoaiSP"]),
                    MaThuongHieu = Convert.ToInt32(dr["MaThuongHieu"]),
                    TenSP = dr["TenSP"].ToString(),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    MoTaChiTiet = dr["MoTaChiTiet"].ToString(),
                    KhuyenMai1 = dr["KhuyenMai1"].ToString(),
                    KhuyenMai2 = dr["KhuyenMai2"].ToString(),
                    HinhAnh1 = dr["HinhAnh1"].ToString(),
                    HinhAnh2 = dr["HinhAnh2"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),

                });
            }
            return list;
        }

        [HttpPost]
        [Route("create")]

        public string Post([FromBody] SanPham sp)
        {
            string msg = string.Empty;
            try
            {
                sp.type = "insert";
                msg = dbconnect.SanPhamOpt(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] SanPham sp)
        {
            string msg = string.Empty;
            try
            {
                sp.Id_SP = id;
                sp.type = "update";
                msg = dbconnect.SanPhamOpt(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<LoaiSanPhamController>/5
        [HttpDelete]
        [Route("delete/{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                SanPham sp = new SanPham();
                sp.Id_SP = id;
                sp.type = "delete";

                msg = dbconnect.SanPhamOpt(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
