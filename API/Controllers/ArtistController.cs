using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace API.Controllers
{
    public class ArtistController : ApiController
    {
        // POST /artist/search
        [Route("artist/search")]
        public IHttpActionResult ArtistSearch([FromUri]string name)
        {
            System.Data.DataTable data;
            string errorMsg;

            if (name == null || name == "")
            {
                errorMsg = "The name parameter was missing or empty. Please provide a value for the 'name' query parameter.";
                return BadRequest(errorMsg);
            }

            var sql = new SQL();

            sql.Parameters.Add("@name", name);
            data = sql.ExecuteStoredProcedureDT("GetArtistSearch");

            return Ok(data);
        }
        
        // POST /artist/add
        [Route("artist/add")]
        public IHttpActionResult ArtistAdd([FromUri]string name, string biography, string imageURL, string heroURL)
        {
            System.Data.DataTable data;
            var sql = new SQL();

            sql.Parameters.Add("@title", name);
            sql.Parameters.Add("@biography", biography);
            sql.Parameters.Add("@imageURL", imageURL);
            sql.Parameters.Add("@heroURL", heroURL);

            data = sql.ExecuteStoredProcedureDT("AddArtist");

            return Ok(data);
        }
    }
}
