using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BridgeLesson.Models;
using BridgeLesson.Utils;
using BridgeLesson.ViewModels;

namespace BridgeLesson.Tests
{
    [TestClass]
    public class BiddingConverterTests
    {
        [TestMethod]
        public void EmptySequenceList()
        {
            IList<Bid> expected = new List<Bid>();

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence>();

            var result = BiddingConverter.Convert(biddingSequences);

            CollectionAssert.AreEqual(expected.ToList(), result.ToList());
        }

        [TestMethod]
        public void OneSequence()
        {
            IList<Bid> expected = new List<Bid>{ new Bid("N:1H", null) };

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> { new BiddingSequence(@"N:1H;",null)};

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected.Count, result.Count);
            Assert.AreEqual(expected[0].BidSymbol, result[0].BidSymbol);
        }

        [TestMethod]
        public void OneSequenceWithTwoBidsShouldReturnNestedBids()
        {
            var description = "5+Spades";
            var nestedBid = new Bid("E:1S", null, new BiddingSequence { Answer = description });
            var parentBid = new Bid("N:1H", null);
            parentBid.NextBids.Add(nestedBid);

            IList <Bid> expected = new List<Bid> { parentBid};

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> { new BiddingSequence("N:1H; E:1S", description) };

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected.Count, result.Count);
            Assert.AreEqual(expected[0].BidSymbol, result[0].BidSymbol);
            Assert.AreEqual(expected[0].NextBids.Count, result[0].NextBids.Count);
            Assert.AreEqual(expected[0].NextBids[0].BidSymbol, result[0].NextBids[0].BidSymbol);
        }

        [TestMethod]
        public void TwoSequenceWithDifferentFirstBidsShouldReturnTwoNestedBids()
        {
            var description1 = "5+Spades";
            var nestedBid1 = new Bid("E:1S", null, new BiddingSequence { Answer = description1 });
            var parentBid1 = new Bid("N:1H", null);

            var description2 = "7-9 bal";
            var nestedBid2 = new Bid("S:1NT", null, new BiddingSequence { Answer = description2 });
            var parentBid2 = new Bid("N:1S", null);

            parentBid1.NextBids.Add(nestedBid1);
            parentBid2.NextBids.Add(nestedBid2);

            IList<Bid> expected = new List<Bid> { parentBid1, parentBid2 };

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> {
                new BiddingSequence("N:1H; E:1S", description1),
                new BiddingSequence("N:1S; E:1NT", description1)
            };

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected.Count, result.Count);
            Assert.AreEqual(expected[0].BidSymbol, result[0].BidSymbol);
            Assert.AreEqual(expected[0].NextBids.Count, result[0].NextBids.Count);
            Assert.AreEqual(expected[0].NextBids[0].BidSymbol, result[0].NextBids[0].BidSymbol);
        }

        [TestMethod]
        public void TwoSequenceWithTheSameFirstBidsShouldReturnNestedBidsWithoutRepeatBasicSorting()
        {
            //1S
            // -> 1NT
            // -> 2S

            var parentBid1 = new Bid("N:1S", null);

            var description1 = "7-9 bal";
            var nestedBid1 = new Bid("E:1NT", null, new BiddingSequence { Answer = description1});

            var description2 = "7-9 3+Spades";
            var nestedBid2 = new Bid("E:2S", null, new BiddingSequence { Answer = description2 });
            
            parentBid1.NextBids.Add(nestedBid1);
            parentBid1.NextBids.Add(nestedBid2);
            
            IList<Bid> expected = new List<Bid> { parentBid1};

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> {
                new BiddingSequence("N:1S; E:2S", description1),
                new BiddingSequence("N:1S; E:1NT", description2)
            };

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected.Count, result.Count);
            Assert.AreEqual(expected[0].NextBids.Count, result[0].NextBids.Count);
            Assert.AreEqual(expected[0].NextBids[0].BidSymbol, result[0].NextBids[0].BidSymbol);
            
        }

        [TestMethod]
        public void WholeSequenceIsAvailableWithBid()
        {
            //1S
            // -> 1NT
            // -> 2S

            var parentBid1 = new Bid("N:1S", "N:1S;");

            var description1 = "7-9 bal";
            var nestedBid1 = new Bid("E:1NT", "N:1S; E:1NT;", new BiddingSequence { Answer = description1});

            var description2 = "7-9 3+Spades";
            var nestedBid2 = new Bid("E:2S", "N:1S; E:2S;", new BiddingSequence { Answer = description2 });

            parentBid1.NextBids.Add(nestedBid1);
            parentBid1.NextBids.Add(nestedBid2);

            IList<Bid> expected = new List<Bid> { parentBid1 };

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> {
                new BiddingSequence("N:1S; E:2S", description2),
                new BiddingSequence("N:1S; E:1NT", description1)
            };

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected[0].BidSequence, result[0].BidSequence);
            Assert.AreEqual(expected[0].NextBids[0].BidSequence, result[0].NextBids[0].BidSequence);
        }

        [TestMethod]
        public void DescriptionIsCorrect()
        {
            //1S
            // -> 1NT
            // -> 2S

            var parentBid1 = new Bid("N:1S", "N:1S;");

            var description1 = "7-9 bal";
            var nestedBid1 = new Bid("E:1NT", "N:1S; E:1NT;", new BiddingSequence { Answer = description1 });

            var description2 = "7-9 3+Spades";
            var nestedBid2 = new Bid("E:2S", "N:1S; E:2S;", new BiddingSequence { Answer = description2 });

            parentBid1.NextBids.Add(nestedBid1);
            parentBid1.NextBids.Add(nestedBid2);

            IList<Bid> expected = new List<Bid> { parentBid1 };

            IList<BiddingSequence> biddingSequences = new List<BiddingSequence> {
                new BiddingSequence("N:1S; E:2S", description2),
                new BiddingSequence("N:1S; E:1NT", description1)
            };

            var result = BiddingConverter.Convert(biddingSequences);

            Assert.AreEqual(expected[0].OriginalObject.Answer, result[0].OriginalObject.Answer);
            Assert.AreEqual(expected[0].NextBids[0].OriginalObject.Answer, result[0].NextBids[0].OriginalObject.Answer);
        }

    }
}
