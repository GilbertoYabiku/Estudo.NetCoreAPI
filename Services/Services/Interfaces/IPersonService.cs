using Services.DTOs;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IPersonService
    {
        void Save(CreatePersonDTO model);
        void Update(UpdatePersonDTO model);
        void Delete(Guid id);
        PersonDTO Get(Guid id);
        IEnumerable<PersonDTO> GetAll();
    }
}