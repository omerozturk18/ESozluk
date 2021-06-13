namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ContactDateadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
