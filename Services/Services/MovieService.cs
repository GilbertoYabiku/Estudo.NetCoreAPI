using Core.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Services.Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) : base(movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> FindMovieByReleaseYear(int year)
        {
            return _movieRepository.FindMovieByReleaseYear(year);
        }
    }
}