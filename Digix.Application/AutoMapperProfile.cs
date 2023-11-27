using AutoMapper;
using Digix.Application.Dtos;
using Digix.Domain.Entities;

namespace Digix.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateFamilyDto, Family>();
            CreateMap<Family, FamilyDto>();

            CreateMap<CreatePersonDto, Person>();
            CreateMap<CreatePersonDto[], List<Person>>();
            CreateMap<Person, PersonDto>();

            CreateMap<FamilyAnalysis, FamilyAnalysisDto>();
            CreateMap<FamilyAnalysis[], List<FamilyAnalysisDto>>();
        }
    }
}
