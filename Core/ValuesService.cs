using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Data;
using Data.Repositories;
using Data.Records;

namespace Core.Types
{
    public class ValuesService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ValueRecord> _valuesRepo;
        private IRepository<ChangeLogRecord> _changeLogRepo;
        private IRepository<ChangeLogValueRecord> _changeLogValueRepo;
        private IRepository<SortTypeRecord> _sortTypeRepo;

        public static SortByEnum SortBy { get; private set; } = SortByEnum.Unordered;

        public ValuesService() : this(new UnitOfWork<ValuesContext>()) { }

        public ValuesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _valuesRepo = _unitOfWork.GetRepository<ValueRecord>();
            _changeLogRepo = _unitOfWork.GetRepository<ChangeLogRecord>();
            _changeLogValueRepo = _unitOfWork.GetRepository<ChangeLogValueRecord>();
            _sortTypeRepo = _unitOfWork.GetRepository<SortTypeRecord>();
        }

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                SortBy = SortByEnum.Unordered;
                _valuesRepo.Add(new ValueRecord { Value = value.Value });
                _unitOfWork.Save();
            }
        }

        public List<int> GetValues()
        {
            if (SortBy == SortByEnum.Unordered)
                return _valuesRepo.Get().Select(record => record.Value).ToList();

            return _changeLogRepo.Get()
                .OrderByDescending(changeLog => changeLog.Version).First()
                .Values.OrderBy(value => value.Position)
                .Select(valueRecord => valueRecord.Value.Value)
                .ToList();
        }

        public void Reset()
        {
            _changeLogValueRepo.Clear();
            _changeLogRepo.Clear();
            _valuesRepo.Clear();
            _unitOfWork.Save();
            SortBy = SortByEnum.Unordered;
        }

        public void SortValues(SortByEnum currentSortBy)
        {
            var stopwatch = Stopwatch.StartNew();
            var values = _valuesRepo.Get().ToList();
            switch (currentSortBy)
            {
                case SortByEnum.Unordered:
                    values = values.OrderBy(x => x.Value).ToList();
                    SortBy = SortByEnum.Asc;
                    break;
                case SortByEnum.Asc:
                    values = values.OrderByDescending(x => x.Value).ToList();
                    SortBy = SortByEnum.Desc;
                    break;
                case SortByEnum.Desc:
                    values = values.OrderBy(x => x.Value).ToList();
                    SortBy = SortByEnum.Asc;
                    break;
            }

            stopwatch.Stop();

            UpdateChangeLog(stopwatch.ElapsedMilliseconds, values);
        }

        public ChangeLog GetChangeLog()
        {
            return new ChangeLog
            {
                Versions = _changeLogRepo.Get()
                    .Select(changeLog => new Version
                    {
                        VersionNumber = changeLog.Version,
                        SortBy = (SortByEnum)changeLog.SortType.Id,
                        TimeTaken = changeLog.TimeTaken,
                        Values = changeLog.Values.Select(valueRecord => valueRecord.Value.Value).ToList()
                    })
                    .ToList()
            };

        }
        public SortByEnum GetCurrentSortDirection()
        {
            return SortBy;
        }

        public string ExportChangeLog()
        {
            var xmlSerializer = new XmlSerializer(typeof(ChangeLog));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, GetChangeLog());
                return stringWriter.ToString();
            }
        }

        private void UpdateChangeLog(long elapsedMilliseconds, List<ValueRecord> values)
        {
            var changeLogs = _changeLogRepo.Get().ToList();
            var changeLogRecord = new ChangeLogRecord
            {
                Version = changeLogs.Any() ? changeLogs.Max(x => x.Version) + 1 : 1,
                SortType = _sortTypeRepo.Get().FirstOrDefault(sortType => sortType.Id == (int)SortBy),
                TimeTaken = elapsedMilliseconds,
                Values = new List<ChangeLogValueRecord>()
            };

            for (var i = 0; i < values.Count; i++)
            {
                changeLogRecord.Values.Add(new ChangeLogValueRecord
                {
                    Value = values[i],
                    Position = i + 1
                });
            }

            _changeLogRepo.Add(changeLogRecord);
            _unitOfWork.Save();
        }
    }
}