namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _migWriterSta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WritetStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WritetStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}
