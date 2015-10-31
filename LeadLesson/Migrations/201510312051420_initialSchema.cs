namespace LeadLesson.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSchema : DbMigration
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
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.BiddingSystems",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.BiddingSystems");
            DropTable("dbo.BiddingSequences");
        }
    }
}
