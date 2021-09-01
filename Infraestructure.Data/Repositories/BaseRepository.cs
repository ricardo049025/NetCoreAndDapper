using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
using Application.Main.Helpers;

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
            string query = $"SELECT * FROM {typeof(TEntity).Name}";
            using (var connection = context.CreateConnection())
            {
                return connection.Query<TEntity>(query);                
            }
            
        }

        public TEntity GetById(int id)
        {            
            string query = $"SELECT * FROM {typeof(TEntity).Name} where Id = {id}";
            using (var connection = context.CreateConnection())
            {
                return connection.QuerySingleOrDefault<TEntity>(query);                
            }
        }

        public void Add(TEntity entity)
        {
            int inserted = 0;
            StringBuilder builquery = new StringBuilder();
            string query = string.Empty;

            builquery.AppendLine($"INSERT INTO {typeof(TEntity).Name} ({SqlGenericHelper<TEntity>.getObjectPropertiesToStrig(entity)})" );
            builquery.AppendLine($"SELECT {SqlGenericHelper<TEntity>.getObjectPropertiesToStrigWithValues(entity)} ");
            query = builquery.ToString();

            using (var connection = context.CreateConnection())
            {
                inserted += connection.Execute(query);                
            }

        }

        public void Update(int id,TEntity entity)
        {
            int updated = 0;
            StringBuilder builquery = new StringBuilder();
            string query = string.Empty;

            builquery.AppendLine($"UPDATE {typeof(TEntity).Name} SET {SqlGenericHelper<TEntity>.getObjectPropertiesToStrigWithUpdateValues(entity)}" );
            builquery.AppendLine($"WHERE Id = {id}");
            query = builquery.ToString();

            using (var connection = context.CreateConnection())
            {
                updated += connection.Execute(query);                
            }

        }

        public void Delete(int id)
        {
            int deleted = 0;
            string query = $"DELETE FROM {typeof(TEntity).Name} where Id = {id}";
            using (var connection = context.CreateConnection())
            {
                deleted += connection.Execute(query);                
            }
        }
    }
}
