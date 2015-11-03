using LeadLesson.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LeadLesson.Controllers
{
    internal class BiddingRepository
    {
        public readonly BridgeLessonDbContext db;

        public BiddingRepository()
        {
            db = new BridgeLessonDbContext();
        }

        public IList<BiddingSequence> GetBiddingSequences()
        {
            return db.BiddingSequences.ToList();
        }

        public IList<BiddingSystem> GetBiddingSystems()
        {
            return db.BiddingSystems.ToList();
        }

        public IList<BiddingSequence> GetBiddingSequencesBySystem(long biddingSystemId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);
            if (biddingSystem == null)
                throw new ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");
            return biddingSystem.BiddingSystemSequences.Select(bss => bss.BiddingSequence).ToList();
        }

        internal object GetBiddingSequence(int biddingSequenceId)
        {
            return db.BiddingSequences.Find(biddingSequenceId);
        }

        public void AddBiddingSequenceToSystem(long biddingSystemId, long biddingSequenceId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);

            if (biddingSystem == null)
                throw new System.ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");
            if (biddingSystem.BiddingSystemSequences.Any(bss => bss.BiddingSequence.Id == biddingSequenceId))
                return;

            biddingSystem.AddBiddingSequence(db.BiddingSequences.Find(biddingSequenceId));
            db.SaveChanges();
        }

        public void RemoveBiddingSequence(long biddingSystemId, long biddingSequenceId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);
            if (biddingSystem == null)
                throw new System.ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");

            biddingSystem.RemoveBiddingSequence(biddingSequenceId);
            db.SaveChanges();
        }


        public BiddingSequence CreateBiddingSequence(BiddingSequence biddingSequence)
        {
            db.BiddingSequences.Add(biddingSequence);
            db.SaveChanges();
            return biddingSequence;
        }

        public BiddingSystem CreateBiddingSystem(BiddingSystem biddingSystem)
        {
            db.BiddingSystems.Add(biddingSystem);
            db.SaveChanges();
            return biddingSystem;
        }
    }
}