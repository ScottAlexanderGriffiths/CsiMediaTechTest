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
        private CurrentSortDirection _currentSortDirection;

        public ValuesService() : this(new UnitOfWork<ValuesContext>()) { }

        public ValuesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _valuesRepo = _unitOfWork.GetRepository<ValueRecord>();
            _changeLogRepo = _unitOfWork.GetRepository<ChangeLogRecord>();
            _changeLogValueRepo = _unitOfWork.GetRepository<ChangeLogValueRecord>();
            _currentSortDirection = new CurrentSortDirection(_unitOfWork);
        }

        public void AddValue(int? value)
        {
            if (value.HasValue)
            {
                _currentSortDirection.Update(SortByEnum.Unordered);
                _valuesRepo.Add(new ValueRecord { Value = value.Value });
                _unitOfWork.Save();
            }
        }

        public List<int> GetValues()
        {
            if (_currentSortDirection.Get() == SortByEnum.Unordered)
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
            _currentSortDirection.Update(SortByEnum.Unordered);
        }

        public void SortValues(SortByEnum currentSortBy)
        {
            var stopwatch = Stopwatch.StartNew();
            var values = _valuesRepo.Get().ToList();
            switch (currentSortBy)
            {
                case SortByEnum.Unordered:
                    values = values.OrderBy(x => x.Value).ToList();
                    _currentSortDirection.Update(SortByEnum.Asc);
                    break;
                case SortByEnum.Asc:
                    values = values.OrderByDescending(x => x.Value).ToList();
                    _currentSortDirection.Update(SortByEnum.Desc);
                    break;
                case SortByEnum.Desc:
                    values = values.OrderBy(x => x.Value).ToList();
                    _currentSortDirection.Update(SortByEnum.Asc);
                    break;
            }

            stopwatch.Stop();

            UpdateChangeLog(stopwatch.ElapsedMilliseconds, values);
        }

        public ChangeLog GetChangeLog()
        {
            return new ChangeLog
            {
                Versions = _changeLogRepo.Get().ToList()
                    .Select(changeLog => new Version
                    {
                        VersionNumber = changeLog.Version,
                        SortBy = SortBy.From(changeLog.SortType.Name),
                        TimeTaken = changeLog.TimeTaken,
                        Values = changeLog.Values.Select(valueRecord => valueRecord.Value.Value).ToList()
                    })
                    .ToList()
            };

        }
        public SortByEnum GetCurrentSortDirection()
        {
            return _currentSortDirection.Get();
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
                SortType = _currentSortDirection.GetRecord(),
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