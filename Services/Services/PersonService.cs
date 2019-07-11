using AutoMapper;
using Core.Models;
using Infrastructure.Repositories.Interfaces;
using Services.DTOs;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class PersonService : IServiceDTO<PersonDTO>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PersonDTO Get(Guid id)
        {
            Person person = _repository.Find(id);
            
            return _mapper.Map<PersonDTO>(person);
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            IEnumerable<Person> personList = _repository.Get();
            List<PersonDTO> personDTOList = new List<PersonDTO>();
            foreach (Person person in personList)
            {
                personDTOList.Add(_mapper.Map<PersonDTO>(person));
            }
            return personDTOList;
        }

        public void Update(PersonDTO model)
        {
            if (model != null)
            {
                _repository.Update(_mapper.Map<Person>(model));
            }
        }
    }
}