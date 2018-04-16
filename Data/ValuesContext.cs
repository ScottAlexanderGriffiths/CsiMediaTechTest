using Data.Records;
using System.Data.Entity;

namespace Data
{
    internal class ValuesContext : DbContext
    {
        public ValuesContext() : base("AzureDb") {}

        public DbSet<ValueRecord> Values { get; set; }
    }
}
