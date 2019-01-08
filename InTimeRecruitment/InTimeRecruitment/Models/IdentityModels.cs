using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InTimeRecruitment.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string CompanyName { get; set; }
        public string CompanyRegNum { get; set; }
        public virtual ICollection<AvatarImage> AvatarImages { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<AvatarImage> AvatarImages { get; set; }
        public DbSet<CandidateProfile> CandidateProfile { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistory { get; set; }
        public DbSet<Qualification> Qualification { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Vacancy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class CandidateProfile
    {
        //User Data
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string Summary { get; set; }
        public string Skills { get; set; }
        public string Languages { get; set; }
        public bool LicenseHolder { get; set; }
        public bool CarOwner { get; set; }

        //TODO: Add social links
        //public List<string> SocialLinks { get; set; }

        //Prefered Work
        public string PrefSalary { get; set; }
        public string PrefLocation { get; set; }
        public string PrefContractType { get; set; }
        public string PrefRole { get; set; }

        //Current Employment
        public string CurEmpStartDate { get; set; }
        public string CurEmpCompany { get; set; }
        public string CurEmpJobTitle { get; set; }
        public string CurEmpResponsibilities { get; set; }
        public string CurEmpSkillsUsed { get; set; }

        //Work Experience
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        //Employment History
        public virtual ICollection<EmploymentHistory> EmpHistory { get; set; }
        //Current Qualifications
        public virtual ICollection<Qualification> Qualifications { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        public string EmpExpStartDate { get; set; }
        public string EmpExpEndDate { get; set; }
        public string EmpExpCompany { get; set; }
        public string EmpExpJobTitle { get; set; }
        public string EmpExpResponsibilities { get; set; }
        public string EmpExpSkillsUsed { get; set; }

        public int CandidateProfileId { get; set; }
        public virtual CandidateProfile CandidateProfile { get; set; }
    }

    public class EmploymentHistory
    {
        [Key]
        public int Id { get; set; }
        public string EmpHistStartDate { get; set; }
        public string EmpHistEndDate { get; set; }
        public string EmpHistCompany { get; set; }
        public string EmpHistJobTitle { get; set; }
        public string EmpHistResponsibilities { get; set; }
        public string EmpHistSkillsUsed { get; set; }

        public int CandidateProfileId { get; set; }
        public virtual CandidateProfile CandidateProfile { get; set; }
    }

    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        public string QualStartDate { get; set; }
        public string QualEndDate { get; set; }
        public string QualType { get; set; }
        public string QualObtainedFrom { get; set; }
        public string QualName { get; set; }
        public string QualCourseName { get; set; }
        public string QualGrade { get; set; }

        public int CandidateProfileId { get; set; }
        public virtual CandidateProfile CandidateProfile { get; set; }
    }

    public class AvatarImage
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class CVs
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}