namespace LeadLesson.Models
{
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