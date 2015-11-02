namespace LeadLesson.Models
{
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