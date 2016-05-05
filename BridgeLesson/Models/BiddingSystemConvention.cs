using System.Diagnostics;

namespace BridgeLesson.Models
{
    [DebuggerDisplay("BiddingSystem = {BiddingSystem}, BiddingSequence={BiddingConvention}")]
    public class BiddingSystemConvention : BaseEntity
    {      
        public virtual BiddingSystem BiddingSystem{ get; set; }
        public virtual BiddingConvention BiddingConvention { get; set; }

        public BiddingSystemConvention()
        {

        }

        public BiddingSystemConvention(BiddingSystem biddingSystem, BiddingConvention biddingConvention)
        {
            BiddingSystem = biddingSystem;
            BiddingConvention = biddingConvention;
        }
    }
}