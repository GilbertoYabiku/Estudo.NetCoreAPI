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
        private readonly IPersonService _service;

        /// <summary>
        /// PersonController Constructor
        /// </summary>
        /// <param name="service"></param>
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a specific Person by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A person</returns>
        [HttpGet("{id}")]
        public ActionResult<PersonDTO> GetById(Guid id)
        {
            var person = _service.Get(id);
            return Ok(person);
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
        /// <param name="createPersonDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPost]
        public ActionResult Post([FromBody] CreatePersonDTO createPersonDTO)
        {
            try
            {
                _service.Save(createPersonDTO);
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
        /// <param name="updatePersonDTO"></param>
        /// <returns>A requistion status code</returns>
        [HttpPut]
        public ActionResult Put([FromBody] UpdatePersonDTO updatePersonDTO)
        {
            try
            {
                _service.Update(updatePersonDTO);
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
        /// Deletes a specific Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A requistion status code</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
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
    }
}