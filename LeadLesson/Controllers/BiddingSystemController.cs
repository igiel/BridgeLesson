using System.Web.Http;

namespace LeadLesson.Controllers
{
    public class BiddingSystemController : ApiController
    {
        private static readonly BiddingRepository biddingRepository = new BiddingRepository();

        // GET: api/BiddingSystem
        public IHttpActionResult Get()
        {
            var biddingSequences = biddingRepository.GetBiddingSequences();
            return Ok(biddingSequences);
        }

        // GET: api/BiddingSystem/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BiddingSystem
        public void Post([FromBody]BiddingSequence biddingSequence)
        {
            biddingRepository.AddBiddingSequence(biddingSequence);
        }

        // PUT: api/BiddingSystem/5
        public void Put(int id, [FromBody]BiddingSequence biddingSequence)
        {
            biddingRepository.AddBiddingSequence(biddingSequence);
        }

        // DELETE: api/BiddingSystem/5
        public void Delete(int id)
        {
        }

       
    }
}
