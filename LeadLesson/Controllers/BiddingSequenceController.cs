using LeadLesson.Models;
using System.Web.Http;

namespace LeadLesson.Controllers
{
    public class BiddingSequenceController : ApiController
    {
        private readonly BiddingRepository biddingRepository = new BiddingRepository();

        // GET: api/BiddingSequence
        public IHttpActionResult Get()
        {
            var biddingSequences = biddingRepository.GetBiddingSequences();
            return Ok(biddingSequences);
        }

        // GET: api/BiddingSequence/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BiddingSequence
        public BiddingSequence Post([FromBody]BiddingSequence biddingSequence)
        {
            return biddingRepository.CreateBiddingSequence(biddingSequence);
        }

        // PUT: api/BiddingSequence/5
        public BiddingSequence Put(int id, [FromBody]BiddingSequence biddingSequence)
        {
            return biddingRepository.CreateBiddingSequence(biddingSequence);
        }

        // DELETE: api/BiddingSequence/5
        public void Delete(int id)
        {
        }

    }
}
