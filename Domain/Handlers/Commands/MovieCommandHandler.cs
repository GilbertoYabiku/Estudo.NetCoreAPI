using AutoMapper;
using Core.CQRS;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Handlers.Commands
{
    public class MovieCommandHandler : IHandler<CreateMovieCommand>,
        IHandler<UpdateMovieCommand>,
        IHandler<RemoveMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public void Handle(CreateMovieCommand Message)
        {
            if(Message != null)
            {
                var movie = _mapper.Map<Movie>(Message);
                _movieRepository.Add(movie);
            }
        }

        public void Handle(UpdateMovieCommand Message)
        {
            if(Message != null)
            {
                var movie = _mapper.Map<Movie>(Message);
                _movieRepository.Update(movie);
            }
        }

        public void Handle(RemoveMovieCommand Message)
        {
            var movie = _movieRepository.Find(Message.Id);
            if(movie != null)
            {
                _movieRepository.Remove(Message.Id);
            }
        }
    }
}