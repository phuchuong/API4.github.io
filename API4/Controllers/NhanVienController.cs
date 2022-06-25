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
    public class NhanVienController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetNhanVien")]

        public List<NhanVien> Get()
        {
            NhanVien nv = new NhanVien();
            nv.type = "get";
            DataSet ds = dbconnect.NhanvienGet(nv, out msg);
            List<NhanVien> list = new List<NhanVien>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new NhanVien
                {
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    TenNV = dr["TenNV"].ToString(),
                    GioiTinh = dr["GioiTinh"].ToString(),
                    /*NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()),*/
                    NgaySinh = dr["NgaySinh"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),
                    TrangThai = Convert.ToInt32(dr["TrangThai"]),
                    taikhoan = dr["taikhoan"].ToString(),
                    matkhau = dr["matkhau"].ToString(),
                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<NhanVien> Get(int id)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = id;
            nv.type = "getid";
            DataSet ds = dbconnect.NhanvienGet(nv, out msg);
            List<NhanVien> list = new List<NhanVien>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new NhanVien
                {
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    TenNV = dr["TenNV"].ToString(),
                    GioiTinh = dr["GioiTinh"].ToString(),
                    NgaySinh = dr["NgaySinh"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),
                    TrangThai = Convert.ToInt32(dr["TrangThai"]),
                    taikhoan = dr["taikhoan"].ToString(),
                    matkhau = dr["matkhau"].ToString(),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] NhanVien nv)
        {
            string msg = string.Empty;
            try
            {
                nv.type = "insert";
                msg = dbconnect.NhanvienOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] NhanVien nv)
        {
            string msg = string.Empty;
            try
            {
                nv.MaNV = id;
                nv.type = "update";
                msg = dbconnect.NhanvienOpt(nv);
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
                NhanVien nv = new NhanVien();
                nv.MaNV = id;

                nv.type = "delete";
                msg = dbconnect.NhanvienOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
