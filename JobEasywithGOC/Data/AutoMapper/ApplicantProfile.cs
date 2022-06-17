
using AutoMapper;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasywithGOC.Data
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            this.CreateMap<Applicant, ApplicantViewModel>()
              //.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
              //.ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
              //.ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
              //.ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
              //.ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
              ////.ForMember(dest => dest., act => act.MapFrom(src => src.StartingDate))
              ////.ForMember(dest => dest.Contact, act => act.MapFrom(src => src.Contact))
              //.ForMember(dest => dest.Country, act => act.MapFrom(src => src.Country))
              //.ForMember(dest => dest.Province, act => act.MapFrom(src => src.Province))
              .ReverseMap();
           
        }
        
    }
    public class CountryProfile: Profile
    {
        public CountryProfile()
        {
            this.CreateMap<Country, CountryViewModel>()
             //.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
             //.ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
             //.ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
             //.ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
             //.ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
             ////.ForMember(dest => dest., act => act.MapFrom(src => src.StartingDate))
             ////.ForMember(dest => dest.Contact, act => act.MapFrom(src => src.Contact))
             //.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
             ////.ForMember(dest => dest.ProvinceId, act => act.MapFrom(src => src.Province.Id))
             .ReverseMap();
        }
    }
    public class ProvinceProfile : Profile
    {
        public ProvinceProfile()
        {
            this.CreateMap<Province, ProvinceViewModel>()
             //.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
             //.ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
             //.ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
             //.ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
             //.ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
             ////.ForMember(dest => dest., act => act.MapFrom(src => src.StartingDate))
             ////.ForMember(dest => dest.Contact, act => act.MapFrom(src => src.Contact))
             //.ForMember(dest => dest.CountryId, act => act.MapFrom(src => src.Country.Id))
             //.ForMember(dest => dest.ProvinceId, act => act.MapFrom(src => src.Province.Id))
             .ReverseMap();
        }
    }
}