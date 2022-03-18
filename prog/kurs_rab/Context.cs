using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_rab
{
    class Context : DbContext
    {
        public Context() : base("Server=.\\SQLEXPRESS;Database=MyDb;Integrated Security=SSPI")
        {

        }
        public DbSet<Accounts> Accounts { get; set; }
    }
}
