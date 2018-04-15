using System.Collections.Generic;
using System.Linq;
using CsiMediaTechTest.Models;

namespace CsiMediaTechTest.Services
{
    public class ValuesService
    {
        public SortByEnum SortBy { get; set; }

        private List<int> Values { get; set; } = new List<int>();

        public void AddValue(int value)
        {
            SortBy = SortByEnum.Unordered;
            Values.Add(value);
        }

        public List<int> GetValues()
        {
            return Values;
        }

        public void SortValues(SortByEnum currentSortBy)
        {
            switch (currentSortBy)
            {
                case SortByEnum.Unordered:
                    Values = Values.OrderBy(x => x).ToList();
                    SortBy = SortByEnum.Asc;
                    break;
                case SortByEnum.Asc:
                    Values = Values.OrderByDescending(x => x).ToList();
                    SortBy = SortByEnum.Desc;
                    break;
                case SortByEnum.Desc:
                    Values = Values.OrderBy(x => x).ToList();
                    SortBy = SortByEnum.Asc;
                    break;
            }
        }
    }
}