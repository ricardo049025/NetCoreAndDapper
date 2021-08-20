using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Service.BaseService{
    
    public interface IBaseService<TEntity> where TEntity : class{

        
        IEnumerable<TEntity> GetAll();

    }

}