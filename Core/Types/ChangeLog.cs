using System.Collections.Generic;

namespace Core.Types
{
    public class ChangeLog
    {
        public List<Version> Versions { get; set; } = new List<Version>();
    }
}