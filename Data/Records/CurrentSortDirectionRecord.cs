using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Records
{
    [Table("CurrentSortDirection")]
    public class CurrentSortDirectionRecord
    {
        public int Id { get; set; }
        [Required]
        public virtual SortTypeRecord SortType { get; set; }
    }
}
