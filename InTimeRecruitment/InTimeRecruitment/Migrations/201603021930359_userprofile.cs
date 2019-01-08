namespace InTimeRecruitment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Files", newName: "AvatarImages");
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PostCode = c.String(),
                        Summary = c.String(),
                        Skills = c.String(),
                        Languages = c.String(),
                        LicenseHolder = c.Boolean(nullable: false),
                        CarOwner = c.Boolean(nullable: false),
                        PrefSalary = c.String(),
                        PrefLocation = c.String(),
                        PrefContractType = c.String(),
                        PrefRole = c.String(),
                        CurEmpStartDate = c.String(),
                        CurEmpCompany = c.String(),
                        CurEmpJobTitle = c.String(),
                        CurEmpResponsibilities = c.String(),
                        CurEmpSkillsUsed = c.String(),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EmploymentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpHistStartDate = c.String(),
                        EmpHistEndDate = c.String(),
                        EmpHistCompany = c.String(),
                        EmpHistJobTitle = c.String(),
                        EmpHistResponsibilities = c.String(),
                        EmpHistSkillsUsed = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QualStartDate = c.String(),
                        QualEndDate = c.String(),
                        QualType = c.String(),
                        QualObtainedFrom = c.String(),
                        QualName = c.String(),
                        QualCourseName = c.String(),
                        QualGrade = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpExpStartDate = c.String(),
                        EmpExpEndDate = c.String(),
                        EmpExpCompany = c.String(),
                        EmpExpJobTitle = c.String(),
                        EmpExpResponsibilities = c.String(),
                        EmpExpSkillsUsed = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Qualifications", "ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.EmploymentHistories", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.WorkExperiences", new[] { "ProfileId" });
            DropIndex("dbo.Qualifications", new[] { "ProfileId" });
            DropIndex("dbo.EmploymentHistories", new[] { "ProfileId" });
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Qualifications");
            DropTable("dbo.EmploymentHistories");
            DropTable("dbo.UserProfiles");
            RenameTable(name: "dbo.AvatarImages", newName: "Files");
        }
    }
}
