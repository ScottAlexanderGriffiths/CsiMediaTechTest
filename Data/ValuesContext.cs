using Data.Records;
using System.Data.Entity;

namespace Data
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Dispose();
    }

    public class ValuesContext : DbContext, IDbContext
    {
        public ValuesContext() : base() {}

        public DbSet<ValueRecord> Values { get; set; }

        public DbSet<ChangeLogRecord> ChangeLogs { get; set; }
        public DbSet<CurrentSortDirectionRecord> CurrentSortDirection { get; set; }
    }
}
