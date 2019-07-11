using Core.Models;
using Infrastructure.Repositories.Interfaces;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class Service<T> : IService<T> where T : BaseModel
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
            var model = _repository.Find(id);
            if(model != null)
            {
                model.Deleted = true;
                _repository.Update(model);
            }
        }

        public T Get(Guid id)
        {
            var model = _repository.Find(id);
            
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.Get();
        }

        public void Save(T model)
        {
            if(model != null)
            {
                _repository.Add(model);
            }
        }

        public void Update(T model)
        {
            if (model != null)
            {
                _repository.Update(model);
            }
        }
    }
}
