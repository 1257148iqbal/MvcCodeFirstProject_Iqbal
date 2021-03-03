namespace MvcCodeFirstProject_Iqbal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainee", "UploadImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainee", "UploadImage", c => c.String(nullable: false));
        }
    }
}
