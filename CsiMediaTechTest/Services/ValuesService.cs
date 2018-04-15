using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsiMediaTechTest.Services
{
    public class ValuesService
    {
        private List<int> Values { get; set; } = new List<int>();

        public void AddValue(int value)
        {
            Values.Add(value);
        }

        public List<int> GetValues()
        {
            return Values;
        }
    }
}