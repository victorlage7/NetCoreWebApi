using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model.Base
{
    public class BaseEntity
    {

        [Column("id")]
        public long? Id { get; set; }
    }
}
