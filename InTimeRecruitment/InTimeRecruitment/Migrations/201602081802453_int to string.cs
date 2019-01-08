namespace InTimeRecruitment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacancies", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacancies", "UserID", c => c.Int(nullable: false));
        }
    }
}
