using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyCurso.Model.BaseEntity
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

    }
}