using System.Diagnostics;

namespace LeadLesson.Models
{
    [DebuggerDisplay("Sequence = {Sequence}, Answer = {Answer}")]
    public class BiddingSequence : BaseEntity
    {
        public string Sequence { get; set; }
        public string Answer { get; set; }

        public BiddingSequence()
        {

        }

        public BiddingSequence(string sequence, string answer)
        {
            this.Sequence = sequence;

            this.Answer = answer;

        }
    }
}