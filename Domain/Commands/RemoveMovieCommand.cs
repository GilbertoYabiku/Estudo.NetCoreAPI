using Core.CQRS;
using System;

namespace Domain.Commands
{
    public class RemoveMovieCommand : Command
    {
        public RemoveMovieCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
