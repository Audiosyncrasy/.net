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
        public IHttpActionResult Post([FromUri]string name)
        {
            System.Data.DataTable data;
            string errorMsg;

            if (name == null || name == "")
            {
                errorMsg = "Please provide a value for the 'name' query parameter.";
                return Ok(errorMsg);
            }

            var sql = new SQL();

            sql.Parameters.Add("@name", name);
            data = sql.ExecuteStoredProcedureDT("GetArtistSearch");

            return Ok(data);
        }
        
        // GET /artists
        /*[Route("artists")]
        public List<Artist> Get()
        {
            var sql = new SQL();

            sql.Parameters.Add("@name", );
            var data = sql.ExecuteStoredProcedureDT("GetArtistSearch");
        }

        // GET /artist
        [Route("artist/{id}")]
        public Artist Get(int id)
        {
            return artists.Where(a => a.ArtistID == id).FirstOrDefault();
        }
        */

        /*
        // GET api/artist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/artist
        public void Post([FromBody]string value)
        {
        }

        // PUT api/artist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/artist/5
        public void Delete(int id)
        {
        }
        */
    }
}
