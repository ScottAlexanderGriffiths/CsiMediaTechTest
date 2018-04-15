using System.Collections.Generic;

namespace Core.Types
{
    public class Version
    {
        public int VersionNumber { get; set; }
        public SortByEnum SortBy { get; set; }
        public long TimeTaken { get; set; }
        public List<int> Values { get; set; } = new List<int>();
    }
}