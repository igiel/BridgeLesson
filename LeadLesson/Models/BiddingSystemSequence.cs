using System.Diagnostics;

namespace LeadLesson.Models
{
    [DebuggerDisplay("BiddingSystem = {BiddingSystem}, BiddingSequence={BiddingSequence}")]
    public class BiddingSystemSequence : BaseEntity
    {      
        public virtual BiddingSystem BiddingSystem{ get; set; }
        public virtual BiddingSequence BiddingSequence { get; set; }

        public BiddingSystemSequence()
        {

        }

        public BiddingSystemSequence(BiddingSystem biddingSystem, BiddingSequence biddingSequence)
        {
            this.BiddingSystem = biddingSystem;
            this.BiddingSequence = biddingSequence;
        }
    }
}