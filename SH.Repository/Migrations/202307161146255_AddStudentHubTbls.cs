namespace SH.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentHubTbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseInfo",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        Cloak = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.RegisterUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Cloak = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentInfo",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StudentEmail = c.String(),
                        StudentPhone = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        StudentStatus = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        Courses = c.String(),
                        Cloak = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentInfo");
            DropTable("dbo.RegisterUser");
            DropTable("dbo.CourseInfo");
        }
    }
}
