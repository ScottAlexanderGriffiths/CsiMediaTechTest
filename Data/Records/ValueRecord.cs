using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Records
{
    [Table("Values")]
    public class ValueRecord
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
