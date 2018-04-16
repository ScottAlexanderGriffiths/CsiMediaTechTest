using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Records
{
    [Table("ChangeLogs")]
    public class ChangeLogRecord
    {
        [Key]
        public int Id { get; set; }
        public int Version { get; set; }
        public long TimeTaken { get; set; }
        public virtual SortTypeRecord SortType { get; set; }
        public virtual List<ChangeLogValueRecord> Values { get; set; }
    }
}
