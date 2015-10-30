using System.Collections.Generic;

namespace LeadLesson.Controllers
{
    internal class BiddingRepository
    {
        private readonly IList<BiddingSequence> biddingSequences = new List<BiddingSequence>
            {
                new BiddingSequence("N:pass;E:1H;S:1P;N:1NT","7-9 with stopper"),
                new BiddingSequence("N:1H;E:dbl;S:2NT","10-12 4+ H!"),
                new BiddingSequence("N:pass;E:1H;S:1P;N:1NT;E:2C!;S:2D!","7-9 without stopper"),
            };

        public IList<BiddingSequence> GetBiddingSequences()
        {
            return this.biddingSequences;
        }

        public void AddBiddingSequence(BiddingSequence biddingSequence)
        {
            this.biddingSequences.Add(biddingSequence);
        }
        
    }
}