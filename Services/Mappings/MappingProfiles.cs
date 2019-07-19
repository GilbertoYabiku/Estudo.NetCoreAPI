using AutoMapper;
using Domain.Commands;
using Domain.Models;
using Services.DTOs;

namespace Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<CreatePersonCommand, CreatePersonDTO>().ReverseMap();
            CreateMap<UpdatePersonCommand, UpdatePersonDTO>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<Person, UpdatePersonCommand>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<CreateMovieCommand, CreateMovieDTO>().ReverseMap();
            CreateMap<UpdateMovieCommand, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, UpdateMovieCommand>().ReverseMap();
        }
    }
}