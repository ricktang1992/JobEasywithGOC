using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.Data.DataModel
{
    public class Applicant
    {
        public Applicant()
        {
          Province = new Province();
          Country = new Country();
            Isdeleted = 0;
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Province Province { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public int Isdeleted { get; set; }
    }
}
