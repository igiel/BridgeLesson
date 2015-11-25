using System.Data.Entity.Migrations;

namespace BridgeLesson.Migrations
{
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
