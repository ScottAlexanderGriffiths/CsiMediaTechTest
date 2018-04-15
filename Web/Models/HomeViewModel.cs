using Core.Types;
using System.Collections.Generic;

namespace Web.Models
{
    public class HomeViewModel
    {
        public int? Input { get; set; }
        public List<int> Values { get; set; } = new List<int>();
        public SortByEnum SortBy { get; set; }
        public List<Version> ChangeLog = new List<Version>();
    }
}