﻿using System;
using System.Collections.Generic;
using System.Linq;
using BridgeLesson.Models;

namespace BridgeLesson.Controllers
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

        public BiddingSequence GetBiddingSequence(int biddingSequenceId)
        {
            return db.BiddingSequences.Find(biddingSequenceId);
        }

        public BiddingSystem GetBiddingSystem(int id)
        {
            return db.BiddingSystems.Find(id);
        }

        public BiddingSystemSequence AddBiddingSequenceToSystem(long biddingSystemId, long biddingSequenceId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);

            if (biddingSystem == null)
                throw new System.ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");
            if (biddingSystem.BiddingSystemSequences.Any(bss => bss.BiddingSequence.Id == biddingSequenceId))
                return biddingSystem.BiddingSystemSequences.First(bss=> bss.BiddingSequence.Id == biddingSequenceId);

            var biddingSystemSequence = biddingSystem.AddBiddingSequence(db.BiddingSequences.Find(biddingSequenceId));
            db.SaveChanges();

            return biddingSystemSequence;
        }
        
        public BiddingConvention AddBiddingConventionToSystem(long biddingSystemId, long biddingConventionId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);

            if (biddingSystem == null)
                throw new ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");

            var convention = db.BiddingConventions.Find(biddingConventionId);

            biddingSystem.AddSystemConvention(convention);
            //foreach (var biddingSequence in convention.BiddingSequences)
            //{
            //   if (biddingSystem.BiddingSystemSequences.Any(bss => bss.BiddingSequence.Id == biddingSequence.Id))
            //       continue;
            //    biddingSystem.AddBiddingSequence(biddingSequence);
            //}

            db.SaveChanges();

            return convention;
        }

        public void RemoveBiddingSequence(long biddingSystemId, long biddingSequenceId)
        {
            var biddingSystem = db.BiddingSystems.FirstOrDefault(bsys => bsys.Id == biddingSystemId);
            if (biddingSystem == null)
                throw new ArgumentException("Bidding system with id " + biddingSystemId + " doesn't exist.");

            var biddingSystemSequence = db.BiddingSystemSequences.FirstOrDefault(bss => bss.BiddingSystem.Id == biddingSystemId && bss.BiddingSequence.Id == biddingSequenceId);

            if (biddingSystemSequence == null)
                return;

            if (biddingSystem == null)
                throw new ArgumentException(
                    $"Bidding system sequence with with systemId={biddingSystemId} and sequenceid={biddingSequenceId} doesn't exist.");

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