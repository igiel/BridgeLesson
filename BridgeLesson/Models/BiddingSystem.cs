using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BridgeLesson.Models
{
    [DebuggerDisplay("Name = {Name}, BiddingSystemSequences = {BiddingSystemSequences.Count}")]
    public class BiddingSystem : BaseEntity
    {
        public string Name { get; set; }
        public string Description{ get; set; }

        public virtual IList<BiddingSystemSequence> BiddingSystemSequences { get; set; }
        public virtual IList<BiddingSystemConvention> BiddingSystemConventions { get; set; }
              
        public BiddingSystemSequence AddBiddingSequence(BiddingSequence biddingSequence)
        {
            if (this.BiddingSystemSequences == null)
                this.BiddingSystemSequences = new List<BiddingSystemSequence>();

            var biddingSystemSequence = new BiddingSystemSequence(this, biddingSequence);
            this.BiddingSystemSequences.Add(biddingSystemSequence);
            return biddingSystemSequence;

        }

        internal void RemoveBiddingSequence(long biddingSequenceId)
        {
            var biddingSystemSequence = this.BiddingSystemSequences.FirstOrDefault(bss => bss.BiddingSequence.Id == biddingSequenceId);
            if (biddingSystemSequence != null)
                this.BiddingSystemSequences.Remove(biddingSystemSequence);
        }

        public BiddingSystemConvention AddSystemConvention(BiddingConvention biddingConvention)
        {
            if (BiddingSystemConventions == null)
                BiddingSystemConventions = new List<BiddingSystemConvention>();

            var existingConvention =
                BiddingSystemConventions.FirstOrDefault(bsc => bsc.BiddingConvention.Id == biddingConvention.Id);
            if (existingConvention != null)
                return existingConvention;

            var biddingSystemConvention = new BiddingSystemConvention(this, biddingConvention);
            BiddingSystemConventions.Add(biddingSystemConvention);

            foreach (var sequence in biddingConvention.BiddingSequences)
            {
                AddBiddingSequence(sequence);
            }

            return biddingSystemConvention;
        }

        internal void RemoveConvention(long conventionId)
        {
            var biddingSystemConvention = BiddingSystemConventions.FirstOrDefault(bsc => bsc.BiddingConvention.Id == conventionId);

            if (biddingSystemConvention == null)
                return;

            foreach (var biddingSequence in biddingSystemConvention.BiddingConvention.BiddingSequences)
            {
                RemoveBiddingSequence(biddingSequence.Id);
            }

            BiddingSystemConventions.Remove(biddingSystemConvention);
        }

    }
}