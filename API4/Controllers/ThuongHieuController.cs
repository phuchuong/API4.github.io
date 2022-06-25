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
    public class ThuongHieuController : ControllerBase
    {
        db dbconnect = new db();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>

        [HttpGet]
        [Route("GetThuongHieu")]

        public List<ThuongHieu> Get()
        {
            ThuongHieu sp = new ThuongHieu();
            sp.type = "get";
            DataSet ds = dbconnect.ThuongHieuGet(sp, out msg);
            List<ThuongHieu> list = new List<ThuongHieu>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ThuongHieu
                {
                    MaThuongHieu = Convert.ToInt32(dr["MaThuongHieu"]),
                    TenThuongHieu = dr["TenThuongHieu"].ToString(),


                });
            }
            return list;
        }

        // GET api/<LoaiSPController>/5
        [HttpGet("{id}")]
        public List<ThuongHieu> Get(int id)
        {
            ThuongHieu sp = new ThuongHieu();
            sp.MaThuongHieu = id;
            sp.type = "getid";
            DataSet ds = dbconnect.ThuongHieuGet(sp, out msg);
            List<ThuongHieu> list = new List<ThuongHieu>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ThuongHieu
                {
                    MaThuongHieu = Convert.ToInt32(dr["MaThuongHieu"]),
                    TenThuongHieu = dr["TenThuongHieu"].ToString(),


                });
            }
            return list;
        }
        [HttpPost]
        [Route("create")]

        public string Post([FromBody] ThuongHieu sp)
        {
            string msg = string.Empty;
            try
            {
                sp.type = "insert";
                msg = dbconnect.ThuongHieuOpt(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public string Put(int id, [FromBody] ThuongHieu sp)
        {
            string msg = string.Empty;
            try
            {
                sp.MaThuongHieu = id;
                sp.type = "update";
                msg = dbconnect.ThuongHieuOpt(sp);
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
                ThuongHieu sp = new ThuongHieu();
                sp.MaThuongHieu = id;
                sp.type = "delete";

                msg = dbconnect.ThuongHieuOpt(sp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
