using System.Diagnostics;

namespace BridgeLesson.Models
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

        internal void CopyValuesFrom(BiddingSequence seq)
        {
            this.Id = seq.Id;
            this.Answer = seq.Answer;
            this.Sequence = seq.Sequence;
            this.CreationDate = seq.CreationDate;
        }
    }
}