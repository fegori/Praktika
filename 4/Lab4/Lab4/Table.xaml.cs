using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        public Table()
        {
            InitializeComponent();
            refreshTab();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                var login = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@login",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 50,
                    Value = login_tb.Text.ToString()
                };
                var password = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 50,
                    Value = password_tb.Text.ToString()
                };
                var result = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@result",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 250
                };
                db.Database.ExecuteSqlRaw("AddAccount @login, @password, @result OUTPUT", login, password, result);
                if (result.Value.ToString() == "Success")
                {
                    MessageBox.Show("Аккаунт добавлен");
                    refreshTab();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        public void refreshTab()
        {
            using (Context db = new Context())
            {
                List<DataGrid> elems = new List<DataGrid>();
                var acc = db.Accounts;
                foreach (Account ac in acc)
                {
                    elems.Add(new DataGrid(ac));
                }
                AccountT.ItemsSource = elems;
            }
        }
    }
}