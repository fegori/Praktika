using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для dbRedactor2.xaml
    /// </summary>
    public partial class dbRedactor2 : Window
    {
        string login;
        string role;
        public krEntities db = new krEntities();
        public dbRedactor2(string table, string uLogin, string uRole)
        {
            login = uLogin;
            role = uRole;
            InitializeComponent();
            mainLabel.Content = table;
            switch (table)
            {
                case "Поставщики":
                    db.Поставщики.Load();
                    tablesGridPostavshiki.ItemsSource = db.Поставщики.Local;
                    tablesGridPostavshiki.Visibility = Visibility.Visible;
                    bDelPostavshiki.Visibility = Visibility.Visible;
                    break;
                case "Заказы":
                    db.Заказы.Load();
                    tablesGridZakazi.ItemsSource = db.Заказы.Local;
                    tablesGridZakazi.Visibility = Visibility.Visible;
                    bDelZakazi.Visibility = Visibility.Visible;
                    break;
                case "ПокупкиТоваров":
                    db.ПокупкиТоваров.Load();
                    tablesGridPokupkiTovarov.ItemsSource = db.ПокупкиТоваров.Local;
                    tablesGridPokupkiTovarov.Visibility = Visibility.Visible;
                    bDelPokupkiTovarov.Visibility = Visibility.Visible;
                    break;
                case "Работники":
                    db.Работники.Load();
                    tablesGridRabotniki.ItemsSource = db.Работники.Local;
                    tablesGridRabotniki.Visibility = Visibility.Visible;
                    bDelRabotniki.Visibility = Visibility.Visible;
                    break;
            }

            this.Closing += MainWindow_Closing;

        }

        private void mm_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(login, role);
            mm.Show();
            this.Close();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }


        private void bDelete_ClickPostavshiki(object sender, RoutedEventArgs e)
        {
            if (tablesGridPostavshiki.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridPostavshiki.SelectedItems.Count; i++)
                {
                    Поставщики a1 = tablesGridPostavshiki.SelectedItems[i] as Поставщики;
                    if (a1 != null)
                    {
                        db.Поставщики.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickZakazi(object sender, RoutedEventArgs e)
        {
            if (tablesGridZakazi.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridZakazi.SelectedItems.Count; i++)
                {
                    Заказы a1 = tablesGridZakazi.SelectedItems[i] as Заказы;
                    if (a1 != null)
                    {
                        db.Заказы.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickPokupkiTovarov(object sender, RoutedEventArgs e)
        {
            if (tablesGridPokupkiTovarov.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridPokupkiTovarov.SelectedItems.Count; i++)
                {
                    ПокупкиТоваров a1 = tablesGridPokupkiTovarov.SelectedItems[i] as ПокупкиТоваров;
                    if (a1 != null)
                    {
                        db.ПокупкиТоваров.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickRabotniki(object sender, RoutedEventArgs e)
        {
            if (tablesGridRabotniki.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridRabotniki.SelectedItems.Count; i++)
                {
                    Работники a1 = tablesGridRabotniki.SelectedItems[i] as Работники;
                    if (a1 != null)
                    {
                        db.Работники.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. " + ex.Message);
            }
        }
    }

}

