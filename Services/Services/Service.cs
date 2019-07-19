using AutoMapper;
using Core.Models;
using Domain.Interfaces;
using Services.DTOs;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : BaseModel
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            var model = _repository.Find(id);
            if (model != null)
            {
                model.Deleted = true;
                _repository.Update(model);
            }
        }

        public TDTO Get<TDTO>(Guid id) where TDTO : BaseDTO
        {
            var model = _repository.Find(id);

            if (model != null)
            {
                return _mapper.Map<TDTO>(model);
            }
            return null;
        }

        public IEnumerable<TDTO> GetAll<TDTO>() where TDTO : BaseDTO
        {
            IEnumerable<TEntity> entityList = _repository.Get();
            List<TDTO> entityDTOList = new List<TDTO>();
            foreach (TEntity entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<TDTO>(entity));
            }
            return entityDTOList;
        }

        public void Save<TDTO>(TDTO model) where TDTO : BaseDTO
        {
            if (model != null)
            {
                _repository.Add(_mapper.Map<TEntity>(model));
            }
        }

        public void Update<TDTO>(TDTO model) where TDTO : BaseDTO
        {
            if (model != null)
            {
                _repository.Update(_mapper.Map<TEntity>(model));
            }
        }
    }
}