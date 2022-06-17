

using AutoMapper;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasywithGOC.Data
{
    public class JobPostProfile : Profile
    {
        public JobPostProfile()
        {
            this.CreateMap<JobPost, JobPostViewModel>()
              .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
              .ForMember(dest => dest.JobTitle, act => act.MapFrom(src => src.JobTitle))
              .ForMember(dest => dest.JobDescription, act => act.MapFrom(src => src.JobDescription))
              .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
              .ForMember(dest => dest.Salary, act => act.MapFrom(src => src.Salary))
              .ForMember(dest => dest.StartingDate, act => act.MapFrom(src => src.StartingDate))
              .ForMember(dest => dest.Contact, act => act.MapFrom(src => src.Contact))
              .ForMember(dest => dest.Education, act => act.MapFrom(src => src.Education))
              .ForMember(dest => dest.Location, act => act.MapFrom(src => src.Location))
              .ReverseMap();
        }
    }
}