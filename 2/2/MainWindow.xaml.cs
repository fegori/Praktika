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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.ComponentModel;

namespace _2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new PeopleContext();
            db.Person.Load();
            dgPeople.ItemsSource = db.Person.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
            
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgPeople.SelectedItems.Count>0)
            {
                for (int i=0;i<dgPeople.SelectedItems.Count; i++) 
                {
                    Person phone = dgPeople.SelectedItems[i] as Person;
                    if (phone != null)
                    {
                        db.Person.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
