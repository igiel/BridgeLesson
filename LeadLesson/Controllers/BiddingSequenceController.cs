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
            var biddingSystem = biddingRepository.CreateOrUpdateBiddingSequence(biddingSequence);
            return Created("biddingSequences",biddingSystem);
        }

        // PUT: api/BiddingSequence/5
        public IHttpActionResult Put(int id, [FromBody]BiddingSequence biddingSequence)
        {
            var biddingSystem = biddingRepository.CreateOrUpdateBiddingSequence(biddingSequence);
            if (id > 0)
                return Ok(biddingSystem);
            else
                return Created("biddingSequences", biddingSequence);
        }

        // DELETE: api/BiddingSequence/5
        public void Delete(int id)
        {
        }

    }
}
