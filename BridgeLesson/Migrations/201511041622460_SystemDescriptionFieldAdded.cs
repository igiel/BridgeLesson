namespace LeadLesson.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemDescriptionFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BiddingSystems", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BiddingSystems", "Description");
        }
    }
}
