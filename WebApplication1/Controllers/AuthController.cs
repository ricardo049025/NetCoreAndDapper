using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Models;
using Infraestructure.Data.Repositories;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private CompanyRepository obj;
        public AuthController(ILogger<AuthController> logger, DapperContext context)
        {
            _logger = logger;
            obj = new CompanyRepository(context);
        }

        [HttpGet]
        [Route("/Auth")]
        public IEnumerable<Company> Get()
        {
             return obj.GetAll();            
        }
    }
}
