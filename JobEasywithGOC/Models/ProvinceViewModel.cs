using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.ViewModels
{
    public class ProvinceViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
