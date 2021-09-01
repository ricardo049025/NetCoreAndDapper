using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;

namespace Application.Main.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public void Add(TEntity entity)
        {
            this.baseRepository.Add(entity);
        }
    }
}