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
                throw new ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");

            var biddingSystemSequence = db.BiddingSystemSequences.FirstOrDefault(bss => bss.BiddingSystem.Id == biddingSystemId && bss.BiddingSequence.Id == biddingSequenceId);
            if (biddingSystem == null)
                throw new ArgumentException( string.Format("Bidding system sequence with with systemId={0} and sequenceid={1} doesn't exist.", biddingSystemId, biddingSequenceId));

            db.BiddingSystemSequences.Remove(biddingSystemSequence);

            db.SaveChanges();
        }


        public BiddingSequence CreateOrUpdateBiddingSequence(BiddingSequence biddingSequence)
        {
            if(biddingSequence.Id>0)
            {
                var biddingSequenceProxy = db.BiddingSequences.Find(biddingSequence.Id);
                biddingSequenceProxy.CopyValuesFrom(biddingSequence);
            }
            else
                db.BiddingSequences.Add(biddingSequence);

            db.SaveChanges();
            return biddingSequence;
        }

        public BiddingSystem CreateBiddingSystem(BiddingSystem biddingSystem, int? systemToCopyId = null)
        {
            db.BiddingSystems.Add(biddingSystem);
            if (systemToCopyId.HasValue)
            {
                var systemToCopy = db.BiddingSystems.Find(systemToCopyId.Value);
                foreach (var bss in systemToCopy.BiddingSystemSequences)
                {
                    biddingSystem.AddBiddingSequence(bss.BiddingSequence);
                } 
            }

            db.SaveChanges();
            return biddingSystem;
        }
    }
}