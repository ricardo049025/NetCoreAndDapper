using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces;

namespace Application.Main.Service.BaseService{
    
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class{

        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository){
            this.baseRepository = baseRepository;
        }

        public IEnumerable<TEntity> GetAll(){
            return this.baseRepository.GetAll();
        }

    }

}