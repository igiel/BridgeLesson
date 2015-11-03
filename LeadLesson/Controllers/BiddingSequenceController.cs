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
        public IHttpActionResult Get(int id)
        {
            var biddingSequence = biddingRepository.GetBiddingSequence(id);
            return Ok(biddingSequence);
        }

        // POST: api/BiddingSequence
        public IHttpActionResult Post([FromBody]BiddingSequence biddingSequence)
        {
            var biddingSystem = biddingRepository.CreateBiddingSequence(biddingSequence);
            return Ok(biddingSystem);
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
