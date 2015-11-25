using System.Data.Entity;

namespace BridgeLesson.Models
{
    public class BridgeLessonDbContext : DbContext
    {
        public BridgeLessonDbContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BridgeLessonDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<BridgeLessonDbContext>());

            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<BiddingSequence> BiddingSequences  { get; set; }
        public DbSet<BiddingSystem> BiddingSystems { get; set; }
        public DbSet<BiddingSystemSequence> BiddingSystemSequences { get; set; }
        public DbSet<BiddingConvention> BiddingConventions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiddingConvention>()
            .HasMany(t => t.BiddingSequences)
            .WithMany()
            .Map(m =>
            {
                m.ToTable("BiddingConventionBiddingSequence");
                m.MapLeftKey("BiddingConvention_Id");
                m.MapRightKey("BiddingSequence_Id");
            });
        }
    }
}