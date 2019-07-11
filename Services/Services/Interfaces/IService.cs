using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IService<T>
    {
        void Save(T model);
        void Update(T model);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}