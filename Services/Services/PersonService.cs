using System;
using System.Collections.Generic;
using AutoMapper;
using Core.CQRS;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;
using Services.DTOs;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public PersonService(IRepository<Person> repository, IMapper mapper, IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new RemovePersonCommand(id));
        }

        public PersonDTO Get(Guid id)
        {
            var model = _repository.Find(id);
            if (model != null)
            {
                return _mapper.Map<PersonDTO>(model);
            }
            return null;
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            IEnumerable<Person> entityList = _repository.Get();
            List<PersonDTO> entityDTOList = new List<PersonDTO>();
            foreach (Person entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<PersonDTO>(entity));
            }
            return entityDTOList;
        }

        public void Save(CreatePersonDTO model)
        {
            var person = _mapper.Map<CreateMovieCommand>(model);
            _bus.SendCommand(person);
        }

        public void Update(UpdatePersonDTO model)
        {
            var person = _mapper.Map<UpdateMovieCommand>(model);
            _bus.SendCommand(person);
        }
    }
}