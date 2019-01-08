using System.ComponentModel.DataAnnotations;

namespace InTimeRecruitment.Models
{
    public class CreateVacancyViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}