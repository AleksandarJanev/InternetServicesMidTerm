using AutoMapper;
using midTerm.Data.Entities;
using midTerm.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace midTerm.Models.Profiles
{
    public class SurveyUserProfile : Profile
    {
        public SurveyUserProfile()
        {
            CreateMap<SurveyUser, SurveyUserModelBase>()
                .ReverseMap();

            CreateMap<SurveyUser, SurveyUserModelExtended>();

            CreateMap<SurveyUserUpdateModel, SurveyUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DoB, opt => opt.MapFrom(src => src.DoB))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();

            CreateMap<SurveyUserCreateModel, SurveyUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DoB, opt => opt.MapFrom(src => src.DoB))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));



        }
    }
}
