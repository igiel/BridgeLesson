using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BridgeLesson.Models;
using BridgeLesson.Utils;
using BridgeLesson.ViewModels;

namespace BridgeLesson.Controllers
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

        [HttpGet]
        [ResponseType(typeof(List<BiddingSequence>))]
        [Route("api/BiddingSystem/{id}")]
        // GET: api/BiddingSystem/5
        public IHttpActionResult Get(int id)
        {
            var biddingSequences = this.biddingRepository.GetBiddingSequencesBySystem(id);
            return Ok(biddingSequences);
        }

        [HttpGet]
        [Route("api/BiddingSystem/AsParentChild/{id}")]
        // GET: api/BiddingSystem/5
        public IHttpActionResult GetAsParentChild(int id)
        {
            var biddingSequences = this.biddingRepository.GetBiddingSequencesBySystem(id);
            var system = this.biddingRepository.GetBiddingSystem(id);

            var rootBid = BiddingConverter.ConvertWithRoot(biddingSequences);
            rootBid.BidSymbol = system.Name;
            var bidsAsParentChild = new BiddingSystemGetAsParentChildViewModel { RootBid = rootBid };
            return Ok(bidsAsParentChild);
        }
        
        // POST: api/BiddingSystem
        [HttpPost]
        [Route("api/BiddingSystem/{systemToCopyId}")]
        public BiddingSystem Post([FromBody]BiddingSystem biddingSystem, int? systemToCopyId = null)
        {
            return biddingRepository.CreateBiddingSystem(biddingSystem, systemToCopyId);
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

        [HttpPut]
        [ResponseType(typeof(BiddingSequence))]
        [Route("api/BiddingSystem/AddBiddingSequenceToSystem/{biddingSystemId}/{biddingSequenceId}")]
        public IHttpActionResult AddBiddingSequenceToSystem(long biddingSystemId, long biddingSequenceId)
        {
            var biddingSystemSequence = this.biddingRepository.AddBiddingSequenceToSystem(biddingSystemId, biddingSequenceId);
            return Ok(biddingSystemSequence.BiddingSequence);
        }

        [HttpPut]
        [ResponseType(typeof(BiddingConvention))]
        [Route("api/BiddingSystem/AddBiddingConventionToSystem/{biddingSystemId}/{biddingConventionId}")]
        public IHttpActionResult AddBiddingConventionToSystem(long biddingSystemId, long biddingConventionId)
        {
            var biddingConvention = this.biddingRepository.AddBiddingConventionToSystem(biddingSystemId, biddingConventionId);
            return Ok(biddingConvention);
        }
        

        [HttpDelete]
        [Route("api/BiddingSystem/RemoveBiddingSequenceFromSystem/{biddingSystemId}/{biddingSequenceId}")]
        public void RemoveBiddingSequenceFromSystem(long biddingSystemId, long biddingSequenceId)
        {
            this.biddingRepository.RemoveBiddingSequence(biddingSystemId, biddingSequenceId);
        }

    }
}
