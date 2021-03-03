namespace MvcCodeFirstProject_Iqbal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamDetail",
                c => new
                    {
                        ExamDetailID = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false, maxLength: 30),
                        ExamDate = c.DateTime(nullable: false),
                        MCQ = c.Int(nullable: false),
                        Evidence = c.Int(nullable: false),
                        TraineeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamDetailID)
                .ForeignKey("dbo.Trainee", t => t.TraineeID, cascadeDelete: true)
                .Index(t => t.TraineeID);
            
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        TraineeID = c.Int(nullable: false, identity: true),
                        TraineeName = c.String(nullable: false, maxLength: 30),
                        EmailAddress = c.String(nullable: false),
                        CellPhone = c.String(maxLength: 11),
                        ContactAddress = c.String(nullable: false, maxLength: 250),
                        TraineeFee = c.String(nullable: false),
                        AdmisionDate = c.DateTime(nullable: false),
                        UploadImage = c.String(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TraineeID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        CellPhone = c.String(nullable: false, maxLength: 11),
                        JoinDate = c.DateTime(nullable: false),
                        ContactAddress = c.String(nullable: false),
                        TecherImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        TrainerName = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.TrainerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainee", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.ExamDetail", "TraineeID", "dbo.Trainee");
            DropIndex("dbo.Trainee", new[] { "TeacherID" });
            DropIndex("dbo.ExamDetail", new[] { "TraineeID" });
            DropTable("dbo.Trainer");
            DropTable("dbo.Teacher");
            DropTable("dbo.Trainee");
            DropTable("dbo.ExamDetail");
        }
    }
}
