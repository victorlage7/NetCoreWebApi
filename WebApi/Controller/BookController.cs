using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.BUS.Interface;
using WebApi.Model;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBus _bookBus;

        public BookController(IBookBus bookBus)
        {
            _bookBus = bookBus;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult Get()
        {
            List<Book> list = new List<Book>();
            list = _bookBus.FindAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBus.FindById(id);
            if (book == null) return BadRequest();
            return Ok(book);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBus.Save(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBus.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBus.Delete(id);
            return NoContent();
        }
    }
}
