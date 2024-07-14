namespace SH.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterTblChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterUser", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterUser", "Email", c => c.String());
        }
    }
}
