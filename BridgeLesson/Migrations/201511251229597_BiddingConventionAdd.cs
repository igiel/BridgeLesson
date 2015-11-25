namespace LeadLesson.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiddingConventionAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiddingConventions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiddingConventionBiddingSequence",
                c => new
                    {
                        BiddingConvention_Id = c.Long(nullable: false),
                        BiddingSequence_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BiddingConvention_Id, t.BiddingSequence_Id })
                .ForeignKey("dbo.BiddingConventions", t => t.BiddingConvention_Id, cascadeDelete: true)
                .ForeignKey("dbo.BiddingSequences", t => t.BiddingSequence_Id, cascadeDelete: true)
                .Index(t => t.BiddingConvention_Id)
                .Index(t => t.BiddingSequence_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BiddingConventionBiddingSequence", "BiddingSequence_Id", "dbo.BiddingSequences");
            DropForeignKey("dbo.BiddingConventionBiddingSequence", "BiddingConvention_Id", "dbo.BiddingConventions");
            DropIndex("dbo.BiddingConventionBiddingSequence", new[] { "BiddingSequence_Id" });
            DropIndex("dbo.BiddingConventionBiddingSequence", new[] { "BiddingConvention_Id" });
            DropTable("dbo.BiddingConventionBiddingSequence");
            DropTable("dbo.BiddingConventions");
        }
    }
}
