using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.ViewModels
{
    public class JobPostViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Job Description")]
        public string JobDescription { get; set; }
        [DisplayName("Company Name")]
        public int Salary { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Education { get; set; }
        [DisplayName("Starting Date")]
        public DateTime StartingDate { get; set; }
        public int Isdeleted { get; set; }



    }
}