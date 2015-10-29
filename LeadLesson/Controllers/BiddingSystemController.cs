using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace LeadLesson.Controllers
{
    public class BiddingSystemController : ApiController
    {
        // GET: api/BiddingSystem
        public HttpResponseMessage Get()
        {
            var biddingSequences = new List<BiddingSequence>
            {
                new BiddingSequence("N:pass;E:1H;S:1P;N:1NT","7-9 with stopper"),
                new BiddingSequence("N:1H;E:dbl;S:2NT","10-12 4+ H!"),
                new BiddingSequence("N:pass;E:1H;S:1P;N:1NT;E:2C!;S:2D!","7-9 without stopper"),
            };
            return Request.CreateResponse(HttpStatusCode.OK, biddingSequences);
            //return new string[] { "value1", "value2" };
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

        class BiddingSequence
        {
            public string Sequence { get; set; }
            public string Answer { get; set; }

            public BiddingSequence(string sequence, string answer)
            {
                this.Sequence = sequence;

                this.Answer = answer;

            }
        }
    }
}
