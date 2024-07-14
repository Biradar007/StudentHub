namespace SH.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInStudentInfoTbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentInfo", "StudentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentInfo", "StudentStatus", c => c.Int(nullable: false));
        }
    }
}
