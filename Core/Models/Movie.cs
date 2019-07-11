using Core.Enums;
using System;

namespace Core.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}