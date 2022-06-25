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
    public class NhaCungCapController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
   

        [HttpGet]
        [Route("GetNhaCungCap")]

        public List<NhaCungCap> Get()
        {
            NhaCungCap nv = new NhaCungCap();
            nv.type = "get";
            DataSet ds = dbconnect.NhaCungCapGet(nv, out msg);
            List<NhaCungCap> list = new List<NhaCungCap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new NhaCungCap
                {
                    MaNCC = Convert.ToInt32(dr["MaNCC"]),
                    TenNCC = dr["TenNCC"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),
                    Email= dr["Email"].ToString(),
      
                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<NhaCungCap> Get(int id)
        {
            NhaCungCap nv = new NhaCungCap();
            nv.MaNCC = id;
            nv.type = "getid";
            DataSet ds = dbconnect.NhaCungCapGet(nv, out msg);
            List<NhaCungCap> list = new List<NhaCungCap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new NhaCungCap
                {
                    MaNCC = Convert.ToInt32(dr["MaNCC"]),
                    TenNCC = dr["TenNCC"].ToString(),
                    SDT = Convert.ToInt32(dr["SDT"]),
                    Email = dr["Email"].ToString(),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] NhaCungCap nv)
        {
            string msg = string.Empty;
            try
            {
                nv.type = "insert";
                msg = dbconnect.NhaCungCapOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] NhaCungCap nv)
        {
            string msg = string.Empty;
            try
            {
                nv.MaNCC = id;
                nv.type = "update";
                msg = dbconnect.NhaCungCapOpt(nv);
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
                NhaCungCap nv = new NhaCungCap();
                nv.MaNCC = id;

                nv.type = "delete";
                msg = dbconnect.NhaCungCapOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
