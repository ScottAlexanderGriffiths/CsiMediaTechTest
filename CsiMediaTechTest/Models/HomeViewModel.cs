using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsiMediaTechTest.Models
{
    public class HomeViewModel
    {
        public int? Input { get; set; }

        public List<int> Values { get; set; } = new List<int>();

        public SortByEnum SortBy { get; set; }
    }
}