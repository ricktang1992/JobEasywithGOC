
using AutoMapper;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasywithGOC.Data
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            this.CreateMap<Company, CompanyViewModel>().ReverseMap();
        }
    }
}