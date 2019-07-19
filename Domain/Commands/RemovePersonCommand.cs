using Core.CQRS;
using System;

namespace Domain.Commands
{
    public class RemovePersonCommand : Command
    {
        public RemovePersonCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}