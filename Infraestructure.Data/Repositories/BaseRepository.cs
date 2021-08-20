using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
namespace Infraestructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DapperContext context;

        public BaseRepository(DapperContext context) 
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            string query = string.Format("SELECT * FROM {0} ", typeof(TEntity).Name);
            using (var connection = context.CreateConnection())
            {
                return connection.Query<TEntity>(query);                
            }
            
        }
    }
}
