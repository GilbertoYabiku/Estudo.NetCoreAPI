using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Services.Interfaces;

namespace App.WebAPI.Controllers
{
    /// <summary>
    /// Controller for Movies
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        /// <summary>
        /// MovieController Constructor
        /// </summary>
        /// <param name="movieService"></param>
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        /// <summary>
        /// Gets all Movies
        /// </summary>
        /// <returns>A list of movies</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetAll()
        {
            return Ok(_movieService.GetAll());
        }
        
        /// <summary>
        /// Get a specific Movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A movie</returns>
        [HttpGet("{id}")]
        public ActionResult<MovieDTO> GetById(Guid id)
        {
            var movie = _movieService.Get(id);
            return Ok(movie);
        }
        
        /// <summary>
        /// Creates a new Movie
        /// </summary>
        /// <param name="createMovieDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPost]
        public ActionResult Post([FromBody] CreateMovieDTO createMovieDTO)
        {
            try
            {
                _movieService.Save(createMovieDTO);
                return Ok();
            }
            catch (Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Model Validation Error",
                    Detail = errors
                });
            }
        }

        /// <summary>
        /// Updates a specific Movie
        /// </summary>
        /// <param name="updateMovieDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPut]
        public ActionResult Put([FromBody] UpdateMovieDTO updateMovieDTO)
        {
            try
            {
                _movieService.Update(updateMovieDTO);
                return Ok();
            }
            catch (Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Model Validation Error",
                    Detail = errors
                });
            }
        }

        /// <summary>
        /// Deletes a specific Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A requistion status code</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                string errors = e.Message;
                return ValidationProblem(new ValidationProblemDetails()
                {
                    Type = "Cannot delete",
                    Detail = errors
                });
            }
        }

        /// <summary>
        /// Gets Movies by Release Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>A list of Movies filtered by Release Year</returns>
        [HttpGet("year/{year}")]
        public ActionResult<IEnumerable<MovieDTO>> FindMovieByReleaseYear(int year)
        {
            return Ok(_movieService.FindMovieByReleaseYear(year));
        }
    }
}