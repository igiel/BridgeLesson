using System.ComponentModel.DataAnnotations;

public class BiddingSequence
{
    [Key]
    public long Id { get; set; }
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