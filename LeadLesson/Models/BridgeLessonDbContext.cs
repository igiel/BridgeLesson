using System.Data.Entity;

namespace LeadLesson.Models
{
    public class BridgeLessonDbContext : DbContext
    {
        public BridgeLessonDbContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BridgeLessonDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<BridgeLessonDbContext>());
        }

        public DbSet<BiddingSequence> BiddingSequences  { get; set; }
        public DbSet<BiddingSystem> BiddingSystem { get; set; }
    }
}