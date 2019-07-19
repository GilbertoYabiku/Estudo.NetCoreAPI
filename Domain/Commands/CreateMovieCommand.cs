using Core.CQRS;
using Domain.Enums;

namespace Domain.Commands
{
    public class CreateMovieCommand : Command
    {
        public CreateMovieCommand(string name, string description, Genre genre, int releaseYear)
        {
            Name = name;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}