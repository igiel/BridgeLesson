using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable VirtualMemberCallInContructor

namespace BridgeLesson.Models
{
    [DebuggerDisplay("BiddingSystem = {BiddingSequences.Count}")]
    public class BiddingConvention : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<BiddingSequence> BiddingSequences { get; set; }

        public BiddingConvention()
        {
        }

        public BiddingConvention(string name, string description, IList<BiddingSequence> biddingSequences )
        {
            this.Name = name;
            this.Description = description;
            this.BiddingSequences = biddingSequences;
        }
    }
}