using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Account
    {
        public int id { get; set; }
        public string login { get; set; }
        public byte[] passwordHash { get; set; }
    }
}
