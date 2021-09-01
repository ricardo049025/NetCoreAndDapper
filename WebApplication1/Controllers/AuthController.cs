using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Models;
using Domain.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

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
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
             return Ok(objCompany.GetAll());            
        }
        
        [HttpGet]
        [Route("getCompanyById/{id:int}")]
        public ActionResult<IEnumerable<Company>> GetCompanyById(int id)
        {
            Company company = objCompany.GetById(id);
            
            if(company == null) return StatusCode(StatusCodes.Status404NotFound,"Error retrieving data from the database");

            return Ok(company);            
        }

        [HttpPost]
        [Route("AddCompany")]
        public ActionResult AddCompany([FromBody]Company company)
        {
            try
            {
                objCompany.Add(company);
                return Ok("Added");
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateCompany/{id:int}")]
        public ActionResult UpdateCompany(int id,[FromBody]Company company)
        {
            try
            {
                Company comp = objCompany.GetById(id);
            
                if(comp == null) return StatusCode(StatusCodes.Status404NotFound,"Error retrieving data from the database");

                objCompany.Update(id,company);
                
                return Ok("Updated");

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteCompany/{id:int}")]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                Company comp = objCompany.GetById(id);
            
                if(comp == null) return StatusCode(StatusCodes.Status404NotFound,"Error retrieving data from the database");

                objCompany.Delete(id);
                
                return Ok("Deleted");

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
