using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeadLesson.Controllers
{
    public class BiddingSystemController : ApiController
    {
        // GET: api/BiddingSystem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BiddingSystem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BiddingSystem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BiddingSystem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BiddingSystem/5
        public void Delete(int id)
        {
        }
    }
}
