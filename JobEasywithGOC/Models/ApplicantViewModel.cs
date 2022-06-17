using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.ViewModels
{
    public class ApplicantViewModel
    {
        public ApplicantViewModel()
        {
            //Country = new CountryViewModel();
            //Province = new ProvinceViewModel();
            Countrylist = new List<SelectListItem>();
            Provincelist = new List<SelectListItem>();
            JobPostList = new List<JobPostViewModel>();
            Isdeleted = 0;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public List<SelectListItem> Provincelist { get; set; }
        public int CountryId { get; set; }
       
        //public CountryViewModel Country { get; set; }
        //public ProvinceViewModel Province { get; set; }
        public List<SelectListItem> Countrylist { get; set; }
        public List<JobPostViewModel> JobPostList { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public int Isdeleted { get; set; }
    }
}
