using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Model.Request;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public LivroController() { }

        [HttpPost]
        [Route("GetLivroById")]
        public Livro GetLivroById([FromBody] JsonLivroRequest livro)
        {
            TryValidateModel(livro);
            Livro livroResponse = new Livro();
            if (ModelState.IsValid)
            { 
                livroResponse.Id = livro.Id;
            }
            return livroResponse;
        
        }
    }
}
