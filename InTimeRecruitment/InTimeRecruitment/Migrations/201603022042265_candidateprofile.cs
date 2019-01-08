namespace InTimeRecruitment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidateprofile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProfiles", newName: "CandidateProfiles");
            RenameColumn(table: "dbo.EmploymentHistories", name: "ProfileId", newName: "CandidateProfileId");
            RenameColumn(table: "dbo.Qualifications", name: "ProfileId", newName: "CandidateProfileId");
            RenameColumn(table: "dbo.WorkExperiences", name: "ProfileId", newName: "CandidateProfileId");
            RenameIndex(table: "dbo.EmploymentHistories", name: "IX_ProfileId", newName: "IX_CandidateProfileId");
            RenameIndex(table: "dbo.Qualifications", name: "IX_ProfileId", newName: "IX_CandidateProfileId");
            RenameIndex(table: "dbo.WorkExperiences", name: "IX_ProfileId", newName: "IX_CandidateProfileId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WorkExperiences", name: "IX_CandidateProfileId", newName: "IX_ProfileId");
            RenameIndex(table: "dbo.Qualifications", name: "IX_CandidateProfileId", newName: "IX_ProfileId");
            RenameIndex(table: "dbo.EmploymentHistories", name: "IX_CandidateProfileId", newName: "IX_ProfileId");
            RenameColumn(table: "dbo.WorkExperiences", name: "CandidateProfileId", newName: "ProfileId");
            RenameColumn(table: "dbo.Qualifications", name: "CandidateProfileId", newName: "ProfileId");
            RenameColumn(table: "dbo.EmploymentHistories", name: "CandidateProfileId", newName: "ProfileId");
            RenameTable(name: "dbo.CandidateProfiles", newName: "UserProfiles");
        }
    }
}
