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
    public class CompanyService: BaseService<Company>, ICompanyService
    {
        protected ICompanyRepository repository;

        public CompanyService(ICompanyRepository repository):base(repository)
        {
        }

    }
}