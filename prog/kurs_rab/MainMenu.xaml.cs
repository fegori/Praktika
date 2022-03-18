using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace kurs_rab
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public string uRole;
        public string uLogin;
        public string[] mas;
        public string table;
        public MainMenu(string login, string role)
        {
            InitializeComponent();
            uRole = role;
            uLogin = login;
            welcomeLabel.Content += login + "!";
            if (role == "admin")
            {
                tAccounts.Visibility = Visibility.Visible;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(-1);
        }

        private void sZakazi_Click(object sender, RoutedEventArgs e)
        {
            table = "Заказы";
            _ = gridListAsync();
        }
        private void sTovari_Click(object sender, RoutedEventArgs e)
        {
            table = "Товары";
            _ = gridListAsync();
            search_cb.Visibility = Visibility.Visible;
        }
        private void sPostavshiki_Click(object sender, RoutedEventArgs e)
        {
            table = "Поставщики";
            _ = gridListAsync();
        }

        private void TovariZakazov_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor mm = new dbRedactor("ТоварыЗаказов", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void Tovari_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor mm = new dbRedactor("Товары", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void Pokupki_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor mm = new dbRedactor("Покупки", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void Postavshiki_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor2 mm = new dbRedactor2("Поставщики", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor2 mm = new dbRedactor2("Заказы", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void TovariPokupok_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor2 mm = new dbRedactor2("ПокупкиТоваров", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        
        private void Rabotniki_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor2 mm = new dbRedactor2("Работники", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void Pokupatel_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor mm = new dbRedactor("Покупатель", uLogin, uRole);
            mm.Show();
            this.Close();
        }
        private void accChange_Click(object sender, RoutedEventArgs e)
        {
            dbRedactor mm = new dbRedactor("Accounts", uLogin, uRole);
            mm.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приложение входит в состав информационной системы \"Система учета товаров\", 2022." +
                " Более подробная информация на сайте https//:XXXXXXXXXXXXXXXXXXXXXXXXX", "Справка");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string order = combobox1.Text;
            string search = searchTB.Text;
            string sql1="";
            for (int i=0;i<mas.Length-1; i++)
            {
                sql1 += mas[i] + ", ";
            }
            sql1 += mas[mas.Length-1];
            string sql2 = "select * from " + table + " where concat(" + sql1 + ") like '%" + search + "%' ";
            if (search_cb.IsChecked==true)
            sql2 += "and Количество>0 ";
            sql2 +="ORDER BY "+order;
            if (combobox2.SelectedIndex == 1)
                sql2 += " desc";

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand createCommand = new SqlCommand(sql2, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable(table);
            dataAdp.Fill(dt);
            tablesGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        //tablesGrid
        public async Task gridListAsync()
        {
            mainLabel.Content = table;
            search_cb.Visibility = Visibility.Hidden;
            welcomeLabel.Visibility = Visibility.Hidden;
            welcomeLabel2.Visibility = Visibility.Hidden;
            searchTB.Visibility = Visibility.Visible;
            searchLabel1.Visibility = Visibility.Visible;
            searchLabel2.Visibility = Visibility.Visible;
            combobox1.Visibility = Visibility.Visible;
            combobox2.Visibility = Visibility.Visible;
            tablesGrid.Visibility = Visibility.Visible;
            searchB.Visibility = Visibility.Visible;
            tablesGrid.IsReadOnly = true;
            string[] mas2 = new string[2];
            mas2[0] = "по возрастанию";
            mas2[1] = "по убыванию";
            combobox2.ItemsSource = mas2;
            combobox2.SelectedIndex = 0;
            tablesGrid.Visibility = Visibility.Visible;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string sql;
            connection.Open();
            sql = "SELECT * FROM " + table;

            SqlCommand createCommand = new SqlCommand(sql, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable(table);
            dataAdp.Fill(dt);
            tablesGrid.ItemsSource = dt.DefaultView;

            SqlDataReader reader = await createCommand.ExecuteReaderAsync();
            int count = reader.FieldCount;
            if (reader.HasRows) // если есть данные
            {
                mas = new string[count];
                for (int i=0;i<count;i++)
                {
                    mas[i]= reader.GetName(i);
                   
                }
                combobox1.ItemsSource = mas;
                combobox1.SelectedIndex = 0;

            }
            connection.Close();
        }
    }
}