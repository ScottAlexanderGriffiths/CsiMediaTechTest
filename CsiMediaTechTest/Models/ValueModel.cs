using System.Collections.Generic;

namespace CsiMediaTechTest.Models
{
    public class ValueModel
    {
        public int Version { get; set; }
        public SortByEnum SortBy { get; set; }
        public List<int> Values { get; set; } = new List<int>();
    }
}