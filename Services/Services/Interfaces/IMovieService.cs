using Services.DTOs;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IMovieService
    {
        void Save(CreateMovieDTO model);
        void Update(UpdateMovieDTO model);
        void Delete(Guid id);
        MovieDTO Get(Guid id);
        IEnumerable<MovieDTO> GetAll();
        IEnumerable<MovieDTO> FindMovieByReleaseYear(int year);
    }
}