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
    public class CTHDNController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetCTHDN")]

        public List<CTHDN> Get()
        {
            CTHDN loai = new CTHDN();
            loai.type = "get";
            DataSet ds = dbconnect.CTHDNGet(loai, out msg);
            List<CTHDN> list = new List<CTHDN>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CTHDN
                {
                    Id_CTHDN = Convert.ToInt32(dr["Id_CTHDN"]),
                    Id_HDN = Convert.ToInt32(dr["Id_HDN"]),
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),


                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<CTHDN> Get(int id)
        {
            CTHDN loai = new CTHDN();
            loai.Id_CTHDN = id;
            loai.type = "getid";
            DataSet ds = dbconnect.CTHDNGet(loai, out msg);
            List<CTHDN> list = new List<CTHDN>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CTHDN
                {
                    Id_CTHDN = Convert.ToInt32(dr["Id_CTHDN"]),
                    Id_HDN = Convert.ToInt32(dr["Id_HDN"]),
                    MaNV = Convert.ToInt32(dr["MaNV"]),
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),

                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] CTHDN loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.CTHDNOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] CTHDN loai)
        {
            string msg = string.Empty;
            try
            {
                loai.Id_CTHDN = id;
                loai.type = "update";
                msg = dbconnect.CTHDNOpt(loai);
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
                CTHDN loai = new CTHDN();
                loai.Id_CTHDN = id;

                loai.type = "delete";
                msg = dbconnect.CTHDNOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
