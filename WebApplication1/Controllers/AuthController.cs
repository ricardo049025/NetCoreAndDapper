using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Models;
using Domain.Domain.Interfaces;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ICompanyService objCompany;

        public AuthController(ILogger<AuthController> logger, ICompanyService  objCompany)
        {
            _logger = logger;
            this.objCompany = objCompany;
        }

        [HttpGet]
        [Route("getCompanies")]
        public ActionResult<IEnumerable<Company>> Get()
        {
             return Ok(objCompany.GetAll());            
        }
    }
}
