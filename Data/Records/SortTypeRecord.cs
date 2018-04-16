using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Records
{
    [Table("SortTypes")]
    public class SortTypeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
