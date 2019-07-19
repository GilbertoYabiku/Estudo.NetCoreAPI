using Core.CQRS;
using Domain.Enums;
using System;

namespace Domain.Commands
{
    public class UpdateMovieCommand : Command
    {
        public UpdateMovieCommand(Guid id, string name, string description, Genre genre, int releaseYear)
        {
            Id = id;
            Name = name;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}