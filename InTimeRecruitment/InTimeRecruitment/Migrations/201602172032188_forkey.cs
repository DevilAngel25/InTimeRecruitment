namespace InTimeRecruitment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancies", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vacancies", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vacancies", "User_Id");
            AddForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            AlterColumn("dbo.Vacancies", "UserId", c => c.String());
            DropColumn("dbo.Vacancies", "User_Id");
        }
    }
}
