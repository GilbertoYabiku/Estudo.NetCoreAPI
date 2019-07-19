using Domain.Enums;

namespace Services.DTOs
{
    public class CreateMovieDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}