using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.Data.DataModel
{
    public class Application
    {
        public Application()
        {
            JobPost = new JobPost();
            Applicant = new Applicant();
            Company = new Company();
        }
        [Key]
        public int Id { get; set; }
        public JobPost JobPost { get; set; }
        public Applicant Applicant { get; set; }
        public Company Company { get; set; }
        public int Isdeleted { get; set; }
    }
}
