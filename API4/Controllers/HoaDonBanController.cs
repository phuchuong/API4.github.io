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
    public class HoaDonBanController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetHoaDonBan")]

        public List<HoaDonBan> Get()
        {
            HoaDonBan loai = new HoaDonBan();
            loai.type = "get";
            DataSet ds = dbconnect.HoaDonBanGet(loai, out msg);
            List<HoaDonBan> list = new List<HoaDonBan>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new HoaDonBan
                {
                    Id_HDB = Convert.ToInt32(dr["Id_HDB"]),
                    MaKH = Convert.ToInt32(dr["MaKH"]),
                    ThanhTien = Convert.ToInt32(dr["ThanhTien"]),
                    NgayBan = dr["NgayBan"].ToString(),
                    TrangThai = Convert.ToInt32(dr["TrangThai"]),


                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<HoaDonBan> Get(int id)
        {
            HoaDonBan loai = new HoaDonBan();
            loai.Id_HDB = id;
            loai.type = "getid";
            DataSet ds = dbconnect.HoaDonBanGet(loai, out msg);
            List<HoaDonBan> list = new List<HoaDonBan>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new HoaDonBan
                {
                    Id_HDB = Convert.ToInt32(dr["Id_HDB"]),
                    MaKH = Convert.ToInt32(dr["MaKH"]),
                    ThanhTien = Convert.ToInt32(dr["ThanhTien"]),
                    NgayBan = dr["NgayBan"].ToString(),
                    TrangThai = Convert.ToInt32(dr["TrangThai"]),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] HoaDonBan loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.HoaDonBanOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] HoaDonBan loai)
        {
            string msg = string.Empty;
            try
            {
                loai.Id_HDB = id;
                loai.type = "update";
                msg = dbconnect.HoaDonBanOpt(loai);
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
                HoaDonBan loai = new HoaDonBan();
                loai.Id_HDB = id;

                loai.type = "delete";
                msg = dbconnect.HoaDonBanOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
