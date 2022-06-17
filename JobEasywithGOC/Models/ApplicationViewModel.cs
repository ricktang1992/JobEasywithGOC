using JobEasyWithGOC.Data.DataModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.ViewModels
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            JobPost = new JobPostViewModel();
            Applicant = new ApplicantViewModel();
            Company = new CompanyViewModel();
            JobPostList = new List<SelectListItem>();
            ApplicantList = new List<SelectListItem>();
            CompanyList = new List<SelectListItem>();
        }
        [Key]
        public int Id { get; set; }
        public JobPostViewModel JobPost { get; set; }
        public ApplicantViewModel Applicant { get; set; }
        public CompanyViewModel Company { get; set; }
        public int Isdeleted { get; set; }
        public List<SelectListItem> JobPostList { get; set; }
        public List<SelectListItem> ApplicantList { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
    }
}
