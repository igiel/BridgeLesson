namespace BridgeLesson.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bridgeConventionToSystemRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiddingSystemConventions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreationDate = c.DateTime(),
                        BiddingConvention_Id = c.Long(),
                        BiddingSystem_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiddingConventions", t => t.BiddingConvention_Id)
                .ForeignKey("dbo.BiddingSystems", t => t.BiddingSystem_Id)
                .Index(t => t.BiddingConvention_Id)
                .Index(t => t.BiddingSystem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BiddingSystemConventions", "BiddingSystem_Id", "dbo.BiddingSystems");
            DropForeignKey("dbo.BiddingSystemConventions", "BiddingConvention_Id", "dbo.BiddingConventions");
            DropIndex("dbo.BiddingSystemConventions", new[] { "BiddingSystem_Id" });
            DropIndex("dbo.BiddingSystemConventions", new[] { "BiddingConvention_Id" });
            DropTable("dbo.BiddingSystemConventions");
        }
    }
}
