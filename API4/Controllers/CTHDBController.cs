using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API4;
using API4.Model;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTHDBController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetCTHDB")]

        public List<CTHDB> Get()
        {
            CTHDB loai = new CTHDB();
            loai.type = "get";
            DataSet ds = dbconnect.CTHDBGet(loai, out msg);
            List<CTHDB> list = new List<CTHDB>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CTHDB
                {
                    Id_CTHDB = Convert.ToInt32(dr["Id_CTHDB"]),
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    Id_HDB = Convert.ToInt32(dr["Id_HDB"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    DonGia = Convert.ToInt32(dr["DonGia"]),


                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<CTHDB> Get(int id)
        {
            CTHDB loai = new CTHDB();
            loai.Id_HDB = id;
            loai.type = "getid";
            DataSet ds = dbconnect.CTHDBGet(loai, out msg);
            List<CTHDB> list = new List<CTHDB>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CTHDB
                {
                    Id_CTHDB = Convert.ToInt32(dr["Id_CTHDB"]),
                    Id_SP = Convert.ToInt32(dr["Id_SP"]),
                    Id_HDB = Convert.ToInt32(dr["Id_HDB"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    DonGia = Convert.ToInt32(dr["DonGia"]),

                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] CTHDB loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.CTHDBOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] CTHDB loai)
        {
            string msg = string.Empty;
            try
            {
                loai.Id_CTHDB = id;
                loai.type = "update";
                msg = dbconnect.CTHDBOpt(loai);
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
                CTHDB loai = new CTHDB();
                loai.Id_CTHDB = id;

                loai.type = "delete";
                msg = dbconnect.CTHDBOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
