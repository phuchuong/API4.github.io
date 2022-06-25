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
    public class KhachHangController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetKhachHang")]

        public List<KhachHang> Get()
        {
            KhachHang loai = new KhachHang();
            loai.type = "get";
            DataSet ds = dbconnect.KhachHangGet(loai, out msg);
            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new KhachHang
                {
                    MaKH = Convert.ToInt32(dr["MaKH"]),
                    TenKH = dr["TenKH"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    PassWord = dr["PassWord"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),

                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<KhachHang> Get(int id)
        {
            KhachHang loai = new KhachHang();
            loai.MaKH = id;
            loai.type = "getid";
            DataSet ds = dbconnect.KhachHangGet(loai, out msg);
            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new KhachHang
                {
                    MaKH = Convert.ToInt32(dr["MaKH"]),
                    TenKH = dr["TenKH"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    PassWord = dr["PassWord"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),

                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] KhachHang loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.KhachHangOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] KhachHang loai)
        {
            string msg = string.Empty;
            try
            {
                loai.MaKH = id;
                loai.type = "update";
                msg = dbconnect.KhachHangOpt(loai);
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
                KhachHang loai = new KhachHang();
                loai.MaKH = id;

                loai.type = "delete";
                msg = dbconnect.KhachHangOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
