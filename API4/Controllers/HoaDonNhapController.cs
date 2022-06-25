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
    public class HoaDonNhapController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetHoaDonNhap")]

        public List<HoaDonNhap> Get()
        {
            HoaDonNhap loai = new HoaDonNhap();
            loai.type = "get";
            DataSet ds = dbconnect.HoaDonNhapGet(loai, out msg);
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new HoaDonNhap
                {
                    Id_HDN = Convert.ToInt32(dr["ID_HDN"]),
                    MaNCC= Convert.ToInt32(dr["MaNCC"]),
                    NgayNhap = dr["NgayNhap"].ToString(),
                    TongTien = Convert.ToInt32(dr["TongTien"]),



                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<HoaDonNhap> Get(int id)
        {
            HoaDonNhap loai = new HoaDonNhap();
            loai.Id_HDN = id;
            loai.type = "getid";
            DataSet ds = dbconnect.HoaDonNhapGet(loai, out msg);
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new HoaDonNhap
                {
                    Id_HDN = Convert.ToInt32(dr["ID_HDN"]),
                    MaNCC = Convert.ToInt32(dr["MaNCC"]),
                    NgayNhap = dr["NgayNhap"].ToString(),
                    TongTien = Convert.ToInt32(dr["TongTien"]),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] HoaDonNhap loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.HoaDonNhapOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] HoaDonNhap loai)
        {
            string msg = string.Empty;
            try
            {
                loai.Id_HDN = id;
                loai.type = "update";
                msg = dbconnect.HoaDonNhapOpt(loai);
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
                HoaDonNhap loai = new HoaDonNhap();
                loai.Id_HDN = id;

                loai.type = "delete";
                msg = dbconnect.HoaDonNhapOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
