using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tests.Mock
{
    public class MockUnitOfWork<T> : IUnitOfWork where T : class, new()
    {
        private T _context;
        private Dictionary<Type, object> _repositories;

        public MockUnitOfWork()
        {
            _context = new T();
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var prop = _context.GetType().GetProperty(typeof(TEntity).Name);
            MockRepository<TEntity> repository = null;
            if (prop != null)
            {
                var entityValue = prop.GetValue(_context, null);
                repository = new MockRepository<TEntity>(entityValue as List<TEntity>);
            }
            else
            {
                repository = new MockRepository<TEntity>(new List<TEntity>());
            }
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Save()
        {
        }

        public void Dispose()
        {
        }
    }
}
