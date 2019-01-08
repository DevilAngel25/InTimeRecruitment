namespace InTimeRecruitment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyRegNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyRegNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyRegNum");
        }
    }
}
