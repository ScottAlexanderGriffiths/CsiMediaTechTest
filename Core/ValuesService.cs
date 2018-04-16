using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Data;

namespace Core.Types
{
    public class ValuesService
    {
        public SortByEnum SortBy { get; private set; }

        private List<int> Values = new List<int>();

        private ChangeLog ChangeLog = new ChangeLog();

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

        public List<Version> GetChangeLog()
        {
            return ChangeLog.Versions;
        }

        public string ExportChangeLog()
        {
            var xmlSerializer = new XmlSerializer(typeof(ChangeLog));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, ChangeLog);
                return stringWriter.ToString();
            }
        }

        private void UpdateChangeLog(long sortTime)
        {
            var change = new Version
            {
                VersionNumber = ChangeLog.Versions.Count + 1,
                SortBy = SortBy,
                TimeTaken = sortTime
            };

            foreach(var value in Values)
            {
                change.Values.Add(value);
            }

            ChangeLog.Versions.Add(change);
        }
    }
}