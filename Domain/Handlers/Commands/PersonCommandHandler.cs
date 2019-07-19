using AutoMapper;
using Core.CQRS;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Handlers.Commands
{
    public class PersonCommandHandler : IHandler<CreatePersonCommand>,
        IHandler<UpdatePersonCommand>,
        IHandler<RemovePersonCommand>
    {

        public PersonCommandHandler(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public void Handle(CreatePersonCommand Message)
        {
            if(Message!= null)
            {
                var person = _mapper.Map<Person>(Message);
                _repository.Add(person);
            }
        }

        public void Handle(UpdatePersonCommand Message)
        {
            if(Message!=null)
            {
                var person = _mapper.Map<Person>(Message);
                _repository.Update(person);
            }
        }

        public void Handle(RemovePersonCommand Message)
        {
            var person = _repository.Find(Message.Id);
            if(person!=null)
            {
                _repository.Remove(Message.Id);
            }
        }
    }
}
