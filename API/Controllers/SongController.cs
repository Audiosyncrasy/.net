using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace API.Controllers
{
    public class SongController : ApiController
    {
        
        // GET /song/list
        [Route("song/list")]
        [HttpPost]
        public IHttpActionResult Post([FromUri]int? pageSize, int? pageNumber)
        {
            string errorMsg = "";

            if (pageSize < 1 || pageNumber < 1)
            {
                if (pageSize < 1)
                {
                    errorMsg += $"Invalid pageSize parameter '{pageSize}'. Please provide a page size value of 1 or greater.";
                }

                if (pageNumber < 1)
                {
                    errorMsg += $"Invalid pageNumber parameter '{pageNumber}'. Please provide a page number value of 1 or greater.";
                }

                return BadRequest(errorMsg);
            }

            System.Data.DataTable data;
            var sql = new SQL();
            sql.Parameters.Add("@pageSize", pageSize);
            sql.Parameters.Add("@pageNumber", pageNumber);

            data = sql.ExecuteStoredProcedureDT("GetSongList");

            return Ok(data);
        }
    }
}
