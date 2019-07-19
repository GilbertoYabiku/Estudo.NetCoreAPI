using AutoMapper;
using Core.CQRS;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;
using Services.DTOs;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public MovieService(IMovieRepository repository, IMapper mapper, IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new RemoveMovieCommand(id));
        }

        public IEnumerable<MovieDTO> FindMovieByReleaseYear(int year)
        {
            IEnumerable<Movie> entityList = _repository.FindMovieByReleaseYear(year);
            List<MovieDTO> entityDTOList = new List<MovieDTO>();
            foreach (Movie entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<MovieDTO>(entity));
            }
            return entityDTOList;
        }

        public MovieDTO Get(Guid id)
        {
            var model = _repository.Find(id);
            if (model != null)
            {
                return _mapper.Map<MovieDTO>(model);
            }
            return null;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            IEnumerable<Movie> entityList = _repository.Get();
            List<MovieDTO> entityDTOList = new List<MovieDTO>();
            foreach (Movie entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<MovieDTO>(entity));
            }
            return entityDTOList;
        }

        public void Save(CreateMovieDTO model)
        {
            if(model != null)
            {
                var movie = _mapper.Map<CreateMovieCommand>(model);
                _bus.SendCommand(movie);
            }
        }

        public void Update(UpdateMovieDTO model)
        {
            if (model != null)
            {
                var movie = _mapper.Map<UpdateMovieCommand>(model);
                _bus.SendCommand(movie);
            }
        }
    }
}