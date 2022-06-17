
using AutoMapper;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasywithGOC.Data
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            this.CreateMap<Application, ApplicationViewModel>().ReverseMap();
        }
    }
}