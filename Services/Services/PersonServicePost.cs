using AutoMapper;
using Core.Models;
using Infrastructure.Repositories.Interfaces;
using Services.DTOs;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class PersonServicePost : IServicePost<PersonDTOPost>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public PersonServicePost(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Save(PersonDTOPost model)
        {
            if (model != null)
            {
                _repository.Add(_mapper.Map<Person>(model));
            }
        }
    }
}