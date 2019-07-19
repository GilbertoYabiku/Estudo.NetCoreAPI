using Domain.Enums;
using System;

namespace Services.DTOs
{
    public class MovieDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}