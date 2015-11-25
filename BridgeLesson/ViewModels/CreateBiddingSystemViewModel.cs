using BridgeLesson.Models;
using LeadLesson.Models;

namespace LeadLesson.ViewModels
{
    public class CreateBiddingSystemViewModel
    {
        public BiddingSystem BiddingSystem{ get; set; }

        public long SystemToCloneId { get; set; }
    }
}