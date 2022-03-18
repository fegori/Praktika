using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class DataGrid
    {
        public int id { get; set; }
        public string login {get;set;}
        public string password { get; set; }
        public DataGrid(Account account)
        {
            id = account.id;
            login = account.login;
            using (var sha256 = SHA256.Create())
            {
                //Конвертирование
                var hashedBytes = sha256.ComputeHash(account.passwordHash);
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                password = hash;
            }

        }
    }
}
