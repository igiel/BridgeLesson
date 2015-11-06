using LeadLesson.Models;
using LeadLesson.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeadLesson.Utils
{
    public class BiddingConverter
    {
        public static List<Bid> Convert(IList<BiddingSequence> sequences)
        {
            var bidRoot = new Bid(null, null);

            foreach (var seq in sequences)
            {
                var sequenceWithoutWhitespaces = Regex.Replace(seq.Sequence, @"\s+", "");
                var splitedSequences = sequenceWithoutWhitespaces.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (!splitedSequences.Any())
                    continue;

                var currentBid = bidRoot;

                foreach (var seqBid in splitedSequences)
                {
                    var nextBid = currentBid.NextBids.FirstOrDefault(cb => cb.BidSymbol == seqBid);
                    if (nextBid == null)
                    {
                        nextBid = new Bid(seqBid, null);
                        currentBid.NextBids.Add(nextBid);
                    }
                    currentBid = nextBid;
                }
                currentBid.Description = seq.Answer;
            }

            bidRoot.SortNextBids();

            return bidRoot.NextBids;
        }
    }
}