namespace SH.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        FileType = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
                        Cloak = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentInfo", "State", c => c.String(nullable: false));
            AddColumn("dbo.StudentInfo", "Description", c => c.String());
            DropColumn("dbo.StudentInfo", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentInfo", "Address", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.StudentInfo", "Description");
            DropColumn("dbo.StudentInfo", "State");
            DropTable("dbo.StudentDocs");
        }
    }
}
