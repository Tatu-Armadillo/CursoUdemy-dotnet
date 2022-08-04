using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyCurso.Model
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

    }
}