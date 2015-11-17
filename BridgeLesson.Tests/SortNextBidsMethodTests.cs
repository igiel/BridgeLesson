using LeadLesson.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgeLesson.Tests
{
    [TestClass]
    public class SortNextBidsMethodTests
    {
        [TestMethod]
        public void SortNextBidsMethodOneBid()
        {
            var firstBid = new Bid("E:1D", null);
            
            var rootBid = new Bid(null, null);

            rootBid.NextBids.Add(firstBid);

            rootBid.SortNextBids();

            Assert.AreEqual(rootBid.NextBids[0], firstBid);
        }

        [TestMethod]
        public void SortNextBidsMethod()
        {
            var firstBid = new Bid("E:1D", null);
            var secondBid = new Bid("N:1H", null);
            var thirdBid = new Bid("N:1NT", null);

            var rootBid = new Bid(null, null);

            rootBid.NextBids.Add(secondBid);
            rootBid.NextBids.Add(thirdBid);
            rootBid.NextBids.Add(firstBid);

            rootBid.SortNextBids();

            Assert.AreEqual(rootBid.NextBids[0], firstBid);
            Assert.AreEqual(rootBid.NextBids[1], secondBid);
            Assert.AreEqual(rootBid.NextBids[2], thirdBid);
        }

        [TestMethod]
        public void SortNextBidsMethodDifferentBidLevel()
        {
            var firstBid = new Bid("E:1NT", null);
            var secondBid = new Bid("N:2S", null);
            var thirdBid = new Bid("N:3NT", null);

            var rootBid = new Bid(null, null);

            rootBid.NextBids.Add(secondBid);
            rootBid.NextBids.Add(thirdBid);
            rootBid.NextBids.Add(firstBid);

            rootBid.SortNextBids();

            Assert.AreEqual(rootBid.NextBids[0], firstBid);
            Assert.AreEqual(rootBid.NextBids[1], secondBid);
            Assert.AreEqual(rootBid.NextBids[2], thirdBid);
        }

        [TestMethod]
        public void SortNextBidsMethodSecondLevelDeepes()
        {
            var firstLevelBid = new Bid(null, null);
            var firstBid = new Bid("E:1D", null);
            var secondBid = new Bid("N:1H", null);
            var thirdBid = new Bid("N:1NT", null);

            var rootBid = new Bid(null, null);

            firstLevelBid.NextBids.Add(secondBid);
            firstLevelBid.NextBids.Add(thirdBid);
            firstLevelBid.NextBids.Add(firstBid);

            rootBid.NextBids.Add(firstLevelBid);
            rootBid.SortNextBids();

            Assert.AreEqual(rootBid.NextBids[0].NextBids[0], firstBid);
            Assert.AreEqual(rootBid.NextBids[0].NextBids[1], secondBid);
            Assert.AreEqual(rootBid.NextBids[0].NextBids[2], thirdBid);
        }
    }
}
