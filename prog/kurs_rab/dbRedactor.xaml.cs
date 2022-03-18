using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
    /// Логика взаимодействия для dbRedactor.xaml
    /// </summary>
    public partial class dbRedactor : Window
    {
        string login;
        string role;
        public krEntities db=new krEntities();
        public dbRedactor(string table,string uLogin, string uRole)
        {
            login=uLogin;
            role = uRole;
            InitializeComponent();
            mainLabel.Content = table;
            switch (table){
                case "Accounts":
                    db.Accounts.Load();
                    tablesGrid.ItemsSource = db.Accounts.Local;
                    tablesGrid.Visibility = Visibility.Visible;
                    bDel.Visibility = Visibility.Visible;
                    break;
                case "Товары":
                    db.Товары.Load();
                    tablesGridTovari.ItemsSource = db.Товары.Local;
                    tablesGridTovari.Visibility = Visibility.Visible;
                    bDelTovari.Visibility = Visibility.Visible;
                    break;
                case "ТоварыЗаказов":
                    db.ТоварыЗаказов.Load();
                    tablesGridTovariZakazov.ItemsSource = db.ТоварыЗаказов.Local;
                    tablesGridTovariZakazov.Visibility = Visibility.Visible;
                    bDelTovariZakazov.Visibility = Visibility.Visible;
                    break;
                case "Покупки":
                    db.Покупки.Load();
                    tablesGridPokupki.ItemsSource = db.Покупки.Local;
                    tablesGridPokupki.Visibility = Visibility.Visible;
                    bDelPokupki.Visibility = Visibility.Visible;
                    break;
                case "Покупатель":
                    db.Покупатель.Load();
                    tablesGridPokupatel.ItemsSource = db.Покупатель.Local;
                    tablesGridPokupatel.Visibility = Visibility.Visible;
                    bDelPokupatel.Visibility = Visibility.Visible;
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


        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tablesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGrid.SelectedItems.Count; i++)
                {
                    Accounts a1 = tablesGrid.SelectedItems[i] as Accounts;
                    if (a1 != null)
                    {
                        db.Accounts.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickTovari(object sender, RoutedEventArgs e)
        {
            if (tablesGridTovari.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridTovari.SelectedItems.Count; i++)
                {
                    Товары a1 = tablesGridTovari.SelectedItems[i] as Товары;
                    if (a1 != null)
                    {
                        db.Товары.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickTovariZakazov(object sender, RoutedEventArgs e)
        {
            if (tablesGridTovariZakazov.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridTovariZakazov.SelectedItems.Count; i++)
                {
                    ТоварыЗаказов a1 = tablesGridTovariZakazov.SelectedItems[i] as ТоварыЗаказов;
                    if (a1 != null)
                    {
                        db.ТоварыЗаказов.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickPokupki(object sender, RoutedEventArgs e)
        {
            if (tablesGridPokupki.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridPokupki.SelectedItems.Count; i++)
                {
                    Покупки a1 = tablesGridPokupki.SelectedItems[i] as Покупки;
                    if (a1 != null)
                    {
                        db.Покупки.Remove(a1);
                    }
                }
            }
            db.SaveChanges();
        }
        private void bDelete_ClickPokupatel(object sender, RoutedEventArgs e)
        {
            if (tablesGridPokupatel.SelectedItems.Count > 0)
            {
                for (int i = 0; i < tablesGridPokupatel.SelectedItems.Count; i++)
                {
                    Покупатель a1 = tablesGridPokupatel.SelectedItems[i] as Покупатель;
                    if (a1 != null)
                    {
                        db.Покупатель.Remove(a1);
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
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка. " + ex.Message);
            }

        }
    }

}

