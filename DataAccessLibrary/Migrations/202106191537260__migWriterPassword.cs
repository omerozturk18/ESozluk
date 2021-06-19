namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _migWriterPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "PasswordSalt", c => c.Binary());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "PasswordSalt");
            DropColumn("dbo.Writers", "PasswordHash");
        }
    }
}
