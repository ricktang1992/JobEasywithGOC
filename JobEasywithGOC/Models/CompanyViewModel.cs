
using JobEasyWithGOC.Data.DataModel;
using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            //Province = new Province();
            //Country = new Country();
         
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        //public Province Province { get; set; }
        //public Country Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public int Isdeleted { get; set; }
    }
}
