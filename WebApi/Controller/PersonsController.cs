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
            Log.Information("Usando mais um Serilog");
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

        [HttpDelete]
        public IActionResult Delete(Person person)
        {
            _personBus.Delete(person.Id.Value);
            return NoContent();
        }


    }
}
