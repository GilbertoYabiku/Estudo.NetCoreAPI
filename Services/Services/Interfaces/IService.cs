using Services.DTOs;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IService<TEntity>
    {
        void Save<TDTO>(TDTO model) where TDTO : BaseDTO;
        void Update<TDTO>(TDTO model) where TDTO : BaseDTO;
        void Delete(Guid id);
        TDTO Get<TDTO>(Guid id) where TDTO : BaseDTO;
        IEnumerable<TDTO> GetAll<TDTO>() where TDTO : BaseDTO;
    }
}