using System;
using System.Collections.Generic;
using System.Linq;

namespace LeadLesson.Models
{
    public class BiddingSystem : BaseEntity
    {
        public virtual IList<BiddingSystemSequence> BiddingSystemSequences { get; set; }
              
        public void AddBiddingSequence(BiddingSequence biddingSequence)
        {
            this.BiddingSystemSequences.Add(new BiddingSystemSequence(this, biddingSequence));
        }

        internal void RemoveBiddingSequence(long biddingSequenceId)
        {
            var biddingSystemSequence = this.BiddingSystemSequences.FirstOrDefault(bss => bss.BiddingSequence.Id == biddingSequenceId);
            if (biddingSystemSequence != null)
                this.BiddingSystemSequences.Remove(biddingSystemSequence);
        }
    }
}