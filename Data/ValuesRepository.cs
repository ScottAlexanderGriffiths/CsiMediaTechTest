using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ValuesRepository
    {
        public void Add(int value)
        {
            using (var db = new ValuesContext())
            {
                db.Values.Add(new Records.ValueRecord { Value = value });
                db.SaveChanges();
            }
        }
    }
}
