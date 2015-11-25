using BridgeLesson.Models;

namespace BridgeLesson.ViewModels
{
    public class CreateBiddingSystemViewModel
    {
        public BiddingSystem BiddingSystem{ get; set; }

        public long SystemToCloneId { get; set; }
    }
}