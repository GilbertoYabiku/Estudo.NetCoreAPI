using Core.Models;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IMovieService : IService<Movie>
    {
        IEnumerable<Movie> FindMovieByReleaseYear(int year);
    }
}