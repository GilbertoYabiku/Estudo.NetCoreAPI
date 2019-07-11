using Core.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> FindMovieByReleaseYear(int year);
    }
}