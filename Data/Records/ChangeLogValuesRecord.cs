using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Records
{
    [Table("ChangeLogs_Values")]
    public class ChangeLogValueRecord
    {
        public int Id { get; set; }
        public virtual ValueRecord Value { get; set; }
        public virtual ChangeLogRecord ChangeLog { get; set; }
        public int Position { get; set; }
    }
}
