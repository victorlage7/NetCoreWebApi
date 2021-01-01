using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApi.BUS.Interface;
using WebApi.Model;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBus _personBus;

        public PersonsController(IPersonBus personBus)
        {
            _personBus = personBus;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult Get()
        {
            List<Person> list = new List<Person>();

            list = _personBus.FindAll();

            return Ok(list);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBus.FindById(id);
            if (person == null) return BadRequest();
            return Ok(person);
        }

        [HttpGet]
        [Route("findbyname/{name}")]
        public IActionResult FindByName(string name)
        {
            List<Person> list = new List<Person>();
            list = _personBus.FindByName(name);
            return Ok(list);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBus.Save(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBus.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBus.Delete(id);
            return NoContent();
        }


    }
}
