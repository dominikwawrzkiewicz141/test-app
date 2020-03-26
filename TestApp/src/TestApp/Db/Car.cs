using System.ComponentModel.DataAnnotations.Schema;

namespace Db
{
    [Table("cars", Schema = "appb")]
    public class Car
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("model")]
        public string Model { get; set; }
    }
}
