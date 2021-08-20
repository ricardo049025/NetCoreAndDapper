using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models;
using Domain.Entities;
using Domain.Domain.Interfaces;
namespace Infraestructure.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        protected DapperContext contex;

        public CompanyRepository(DapperContext context) : base(context) 
        {
            this.contex = context;
        }
    }
}
