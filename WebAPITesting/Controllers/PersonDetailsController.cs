using Microsoft.AspNetCore.Mvc;
using BAL_CRUD.Service;
using DAL_CRUD.Interface;
using DAL_CRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebAPITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : Controller
    {
        private readonly PersonService _personService;

        private readonly IRepository<Person> _Person;

        public PersonDetailsController(IRepository<Person> Person, PersonService ProductService)
        {
            _personService = ProductService;
            _Person = Person;

        }
        //Add Person  
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] Person person)
        {
            try
            {
                await _personService.AddPerson(person);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Person  
        [HttpDelete("DeletePerson")]
        public bool DeletePerson(string UserEmail)
        {
            try
            {
                _personService.DeletePerson(UserEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Person  
        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(Person Object)
        {
            try
            {
                _personService.UpdatePerson(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
                        
        //GET All Person  
        [HttpGet("GetAllPersons")]
        public Object GetAllPersons()
        {
            var data = _personService.GetAll();
            var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
