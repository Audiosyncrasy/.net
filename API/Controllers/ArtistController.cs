using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Controllers
{
    public class ArtistController : ApiController
    {
        List<Artist> artists = new List<Artist>();

        public ArtistController()
        {
            artists.Add(new Artist { Name = "Hillsong United", Bio = "This is a bio!", ArtistID = 1 });
            artists.Add(new Artist { Name = "Corey Asbury", Bio = "This is a bio!", ArtistID = 2 });
            artists.Add(new Artist { Name = "Israel Houghton", Bio = "This is a bio!", ArtistID = 3 });
        }

        // GET /artists
        [Route("artists")]
        public List<Artist> Get()
        {
            return artists;
        }

        // GET /artist
        [Route("artist/{id}")]
        public Artist Get(int id)
        {
            return artists.Where(a => a.ArtistID == id).FirstOrDefault();
        }

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
