using Core.Models;
using Infrastructure.Configurations;
using Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ConfigurationContext configurationContext;

        public MovieRepository(ConfigurationContext context) : base(context)
        {
            configurationContext = context;
        }

        public IEnumerable<Movie> FindMovieByReleaseYear(int year)
        {
            return configurationContext.Movies.Where(movie => movie.ReleaseYear == year);
        }
    }
}