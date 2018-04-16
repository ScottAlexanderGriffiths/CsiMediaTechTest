using Core.Types;
using Data.Records;
using Data.Repositories;
using System.Linq;

namespace Core
{
    public class CurrentSortDirection
    {
        private IRepository<CurrentSortDirectionRecord> _currentSortDirectionRepo;
        private IRepository<SortTypeRecord> _sortTypeRepo;
        private IUnitOfWork _unitOfWork;

        public CurrentSortDirection(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _currentSortDirectionRepo = _unitOfWork.GetRepository<CurrentSortDirectionRecord>();
            _sortTypeRepo = _unitOfWork.GetRepository<SortTypeRecord>();
        }

        public SortByEnum Get()
        {
            return SortBy.From(GetRecord().Name);
        }

        public SortTypeRecord GetRecord()
        {
            return _currentSortDirectionRepo.Get().ToList().OrderByDescending(x => x.Id).Select(x => x.SortType).First();
        }

        public void Update(SortByEnum sortBy)
        {
            var sortTypeRecord = _sortTypeRepo.Get().ToList().First(sortType => SortBy.From(sortType.Name) == sortBy);

            _currentSortDirectionRepo.Clear();
            _currentSortDirectionRepo.Add(new CurrentSortDirectionRecord { SortType = sortTypeRecord });
            _unitOfWork.Save();
        }
    }
}
