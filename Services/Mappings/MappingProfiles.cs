using AutoMapper;
using Core.Models;
using Services.DTOs;

namespace Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonDTOPost>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}