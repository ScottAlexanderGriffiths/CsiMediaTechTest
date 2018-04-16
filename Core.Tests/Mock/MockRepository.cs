using Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tests.Mock
{
    public class MockRepository<T> : IRepository<T> where T : class
    {
        public List<T> _context;

        public MockRepository(List<T> ctx)
        {
            _context = ctx;
        }

        public void Add(T record)
        {
            _context.Add(record);
        }

        public void Clear()
        {
            _context.Clear();
        }

        public virtual IQueryable<T> Get()
        {
            return _context.AsQueryable();
        }
    }
}
