using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeadLesson.Models
{
    public class BiddingSystem
    {
        [Key]
        public long Id { get; set; }

        //public virtual IList<BiddingSequence> BiddingSequences { get; set; }
    }
}