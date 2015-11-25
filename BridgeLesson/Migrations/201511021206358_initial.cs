using System.Data.Entity.Migrations;

namespace BridgeLesson.Migrations
{
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiddingSequences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Sequence = c.String(),
                        Answer = c.String(),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiddingSystems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiddingSystemSequences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreationDate = c.DateTime(),
                        BiddingSequence_Id = c.Long(),
                        BiddingSystem_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiddingSequences", t => t.BiddingSequence_Id)
                .ForeignKey("dbo.BiddingSystems", t => t.BiddingSystem_Id)
                .Index(t => t.BiddingSequence_Id)
                .Index(t => t.BiddingSystem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BiddingSystemSequences", "BiddingSystem_Id", "dbo.BiddingSystems");
            DropForeignKey("dbo.BiddingSystemSequences", "BiddingSequence_Id", "dbo.BiddingSequences");
            DropIndex("dbo.BiddingSystemSequences", new[] { "BiddingSystem_Id" });
            DropIndex("dbo.BiddingSystemSequences", new[] { "BiddingSequence_Id" });
            DropTable("dbo.BiddingSystemSequences");
            DropTable("dbo.BiddingSystems");
            DropTable("dbo.BiddingSequences");
        }
    }
}
