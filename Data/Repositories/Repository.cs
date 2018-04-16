using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDbContext _dbcontext;
        private DbSet<T> _dbset;

        public Repository(IDbContext dbContext)
        {
            _dbcontext = dbContext;
            _dbset = _dbcontext.Set<T>();
        }
        public IQueryable<T> Get()
        {
            return _dbset;
        }

        public void Add(T record)
        {
            _dbset.Add(record);
        }
    }
}
