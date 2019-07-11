using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Models;
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
    public class PersonController : ControllerBase
    {
        private readonly IServiceDTO<PersonDTO> _service;
        private readonly IServicePost<PersonDTOPost> _servicePost;

        /// <summary>
        /// PersonController Constructor
        /// </summary>
        /// <param name="service"></param>
        /// /// <param name="servicePost"></param>
        public PersonController(IServiceDTO<PersonDTO> service, IServicePost<PersonDTOPost> servicePost)
        {
            _servicePost = servicePost;
            _service = service;
        }
        
        /// <summary>
        /// Gets all Persons
        /// </summary>
        /// <returns>A list of person</returns>
        [HttpGet]
        public ActionResult<List<PersonDTO>> GetAll()
        {
            
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// Creates a new Person
        /// </summary>
        /// <param name="personDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPost]
        public ActionResult Post([FromBody] PersonDTOPost personDTO)
        {
            try
            {
                _servicePost.Save(personDTO);
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
        /// Updates a specific Person
        /// </summary>
        /// <param name="personDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPut]
        public ActionResult Put([FromBody] PersonDTO personDTO)
        {
            try
            {
                _service.Update(personDTO);
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
    }
}