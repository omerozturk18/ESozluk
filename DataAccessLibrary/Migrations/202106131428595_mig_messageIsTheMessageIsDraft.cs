namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messageIsTheMessageIsDraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsTheMessageIsDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsTheMessageIsDraft");
        }
    }
}
