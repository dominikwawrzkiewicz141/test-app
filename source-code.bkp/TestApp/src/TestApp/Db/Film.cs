using System.ComponentModel.DataAnnotations.Schema;

namespace Db
{
    [Table("films", Schema = "appa")]
    public class Film
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
