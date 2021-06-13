namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactaddIsRead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsRead");
        }
    }
}
