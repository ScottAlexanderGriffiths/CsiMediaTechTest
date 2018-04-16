using System.Linq;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        void Add(T record);
    }
}
