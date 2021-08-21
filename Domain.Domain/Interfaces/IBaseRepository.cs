using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Interfaces
{
    /// <summary>
    /// ASI: Ricardo Martinez.
    /// Base Interfaces for the project
    /// </summary>
    /// <typeparam name="TEntity">Generic entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(int id);
        
    }
}
