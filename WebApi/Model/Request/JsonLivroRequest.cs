using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.Request
{
    public class JsonLivroRequest
    {

        [Required(ErrorMessage = "Please enter a Id value")]
        public int Id { get; set; }
    }
}
