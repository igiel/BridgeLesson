using LeadLesson.Models;
using System.Web.Http;

namespace LeadLesson.Controllers
{
    public class BiddingSystemController : ApiController
    {
        private readonly BiddingRepository biddingRepository = new BiddingRepository();

        // GET: api/BiddingSystem
        public IHttpActionResult Get()
        {
            var biddingSequences = biddingRepository.GetBiddingSystems();
            return Ok(biddingSequences);
        }

        // GET: api/BiddingSystem/5
        public IHttpActionResult Get(int id)
        {
            var biddingSequences = this.biddingRepository.GetBiddingSequencesBySystem(id);
            return Ok(biddingSequences);
        }

        // POST: api/BiddingSystem
        public BiddingSystem Post([FromBody]BiddingSystem biddingSystem)
        {
            return biddingRepository.CreateBiddingSystem(biddingSystem);
        }

        // PUT: api/BiddingSystem/5
        public BiddingSystem Put(int id, [FromBody]BiddingSystem biddingSystem)
        {
            return biddingRepository.CreateBiddingSystem(biddingSystem);
        }

        // DELETE: api/BiddingSystem/5
        public void Delete(int id)
        {

        }

        public void AddBiddingSequenceToSystem(long biddingSystemId, long biddingSequenceId)
        {
            this.biddingRepository.AddBiddingSequenceToSystem(biddingSystemId, biddingSequenceId);
        }
        public void RemoveBiddingSequenceFromSystem(long biddingSystemId, long biddingSequenceId)
        {
            this.biddingRepository.RemoveBiddingSequence(biddingSystemId, biddingSequenceId);
        }

    }
}
