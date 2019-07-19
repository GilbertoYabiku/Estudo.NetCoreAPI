using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> FindMovieByReleaseYear(int year);
    }
}
