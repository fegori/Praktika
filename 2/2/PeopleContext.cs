using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace _2
{
    class PeopleContext: DbContext
    {
        public PeopleContext() : base("Server=.\\SQLEXPRESS;Database=MyDb;Integrated Security=SSPI")
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}
