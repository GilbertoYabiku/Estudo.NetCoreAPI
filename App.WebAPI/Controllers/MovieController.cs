using System;
using System.Collections.Generic;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            return Ok(_movieService.GetAll());
        }
        
        /// <summary>
        /// Get a specific Movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A movie</returns>
        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(Guid id)
        {
            var movie = _movieService.Get(id);
            return Ok(movie);
        }
        
        /// <summary>
        /// Creates a new Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>A requistion status code</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            try
            {
                _movieService.Save(movie);
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
        /// <param name="movie"></param>
        /// <returns>A requistion status code</returns>
        [HttpPut]
        public ActionResult Put([FromBody] Movie movie)
        {
            try
            {
                _movieService.Update(movie);
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
        public ActionResult<IEnumerable<Movie>> FindMovieByReleaseYear(int year)
        {
            return Ok(_movieService.FindMovieByReleaseYear(year));
        }
    }
}