using Core.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public class UpdatePersonCommand : Command
    {
        public UpdatePersonCommand(Guid id, string name, string lastName, DateTime birthdate, string civilRegistry, string email)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Birthdate = birthdate;
            CivilRegistry = civilRegistry;
            Email = email;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public DateTime Birthdate { get; }
        public string CivilRegistry { get; }
        public string Email { get; }
    }
}