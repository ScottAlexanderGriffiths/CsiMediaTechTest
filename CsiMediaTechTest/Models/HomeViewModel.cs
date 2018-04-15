using System.Collections.Generic;

namespace CsiMediaTechTest.Models
{
    public class HomeViewModel
    {
        public int? Input { get; set; }
        public List<int> Values { get; set; } = new List<int>();
        public SortByEnum SortBy { get; set; }
        public List<ValueModel> ChangeLog = new List<ValueModel>();
    }
}