using System.Collections.Generic;
using System.Linq;
using CsiMediaTechTest.Models;
using System.Diagnostics;

namespace CsiMediaTechTest.Services
{
    public class ValuesService
    {
        public SortByEnum SortBy { get; private set; }

        private List<int> Values = new List<int>();

        private List<ValueModel> ChangeLog = new List<ValueModel>();

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                SortBy = SortByEnum.Unordered;
                Values.Add(value.Value);
            }
        }

        public List<int> GetValues()
        {
            return Values;
        }

        public void SortValues(SortByEnum currentSortBy)
        {
            var stopwatch = Stopwatch.StartNew();

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

            stopwatch.Stop();

            UpdateChangeLog(stopwatch.ElapsedMilliseconds);
        }

        public List<ValueModel> GetChangeLog()
        {
            return ChangeLog;
        }

        private void UpdateChangeLog(long sortTime)
        {
            var change = new ValueModel
            {
                Version = ChangeLog.Count + 1,
                SortBy = SortBy,
                TimeTaken = sortTime
            };

            foreach(var value in Values)
            {
                change.Values.Add(value);
            }

            ChangeLog.Add(change);
        }
    }
}