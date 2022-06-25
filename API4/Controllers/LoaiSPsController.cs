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
    public class LoaiSPsController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetLoaiSP")]

        public List<LoaiSP> Get()
        {
            LoaiSP loai = new LoaiSP();
            loai.type = "get";
            DataSet ds = dbconnect.LoaisanphamGet(loai, out msg);
            List<LoaiSP> list = new List<LoaiSP>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new LoaiSP
                {
                    MaLoaiSP = Convert.ToInt32(dr["MaLoaiSP"]),
                    TenLoaiSP = dr["TenLoaiSP"].ToString(),


                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<LoaiSP> Get(int id)
        {
            LoaiSP loai = new LoaiSP();
            loai.MaLoaiSP = id;
            loai.type = "getid";
            DataSet ds = dbconnect.LoaisanphamGet(loai, out msg);
            List<LoaiSP> list = new List<LoaiSP>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new LoaiSP
                {
                    MaLoaiSP = Convert.ToInt32(dr["MaLoaiSP"]),
                    TenLoaiSP = dr["TenLoaiSP"].ToString(),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] LoaiSP loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.LoaisanphamOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] LoaiSP loai)
        {
            string msg = string.Empty;
            try
            {
                loai.MaLoaiSP = id;
                loai.type = "update";
                msg = dbconnect.LoaisanphamOpt(loai);
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
                LoaiSP loai = new LoaiSP();
                loai.MaLoaiSP = id;
            
            loai.type = "delete";
            msg = dbconnect.LoaisanphamOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
