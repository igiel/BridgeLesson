using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeadLesson.Models
{
    [DebuggerDisplay("Name = {Name}, BiddingSystemSequences = {BiddingSystemSequences.Count}")]
    public class BiddingSystem : BaseEntity
    {
        public string Name { get; set; }
        public string Description{ get; set; }

        public virtual IList<BiddingSystemSequence> BiddingSystemSequences { get; set; }
              
        public void AddBiddingSequence(BiddingSequence biddingSequence)
        {
            if (this.BiddingSystemSequences == null)
                this.BiddingSystemSequences = new List<BiddingSystemSequence>();
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