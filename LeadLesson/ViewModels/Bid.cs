using LeadLesson.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeadLesson.ViewModels
{
    public class Bid
    {
        public Bid(string bidSymbol, string bidSequence, BiddingSequence biddingSequence = null)
        {
            this.BidSymbol = bidSymbol;
            this.BidSequence = bidSequence;
            this.OriginalObject = biddingSequence != null ? biddingSequence : new BiddingSequence { Sequence = bidSequence, Id = 0 };
            this.NextBids = new List<Bid>();
        }

        public string BidSymbol { get; set; }

        public string BidSequence { get; set; }
                
        public List<Bid> NextBids { get; set; }

        public BiddingSequence OriginalObject { get; private set; }

        public void SortNextBids()
        {
            if (this.NextBids.Count == 0)
                return;

            this.NextBids.Sort(Compare);

            foreach(var nextBid in this.NextBids)
            {
                nextBid.SortNextBids();
            }
        }

        private static int Compare(Bid x, Bid y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null || x.BidSymbol.Length<3)
                return -1;
            if (y == null || y.BidSymbol.Length < 3)
                return 1;
            var xBid = x.BidSymbol.Substring(2).Replace("pass", "-");
            var yBid = y.BidSymbol.Substring(2).Replace("pass", "-");

            //Luckly, [C]lub, [D]iamond, [H]eart, [S]spade, [NT] is an alphabetical order :)
            //And Level is alphabetial also

            return xBid.CompareTo(yBid);
        }

        public override string ToString()
        {
            return string.Format("Bid symbol: {0}, Description: {1}", BidSymbol, this.OriginalObject.Answer);
        }
    }
}