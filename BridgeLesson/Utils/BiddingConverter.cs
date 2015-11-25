using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BridgeLesson.Models;
using BridgeLesson.ViewModels;

namespace BridgeLesson.Utils
{
    public class BiddingConverter
    {
        public static List<Bid> Convert(IList<BiddingSequence> sequences)
        {
            return ConvertWithRoot(sequences).NextBids;
        }

        public static Bid ConvertWithRoot(IList<BiddingSequence> sequences)
        {
            var bidRoot = new Bid("root", null, null);

            foreach (var seq in sequences)
            {
                if(seq.Sequence==null)
                    continue;

                var sequenceWithoutWhitespaces = Regex.Replace(seq.Sequence, @"\s+", "");
                var splitedSequences = sequenceWithoutWhitespaces.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (!splitedSequences.Any())
                    continue;

                var currentBid = bidRoot;

                var wholeSequence = new StringBuilder();
                foreach (var seqBid in splitedSequences)
                {
                    if(wholeSequence.Length>0)
                        wholeSequence.Append(" ");
                    wholeSequence.Append(seqBid + ";");

                    var nextBid = currentBid.NextBids.FirstOrDefault(cb => cb.BidSymbol == seqBid);
                    if (nextBid == null)
                    {
                        nextBid = new Bid(seqBid, wholeSequence.ToString());
                        currentBid.NextBids.Add(nextBid);
                    }
                    currentBid = nextBid;
                }

                currentBid.OriginalObject.CopyValuesFrom(seq);
            }

            bidRoot.SortNextBids();

            return bidRoot;
        }
    }
}