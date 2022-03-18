using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

using System.Data;
using System.Configuration;
using Path = System.Windows.Shapes.Path;

namespace kurs_rab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string password = pass.Password;
            using (krEntities db = new krEntities())
            {
                loginError.Content = "";
                Accounts a1 = db.Accounts.Where((Accounts) => Accounts.Login == login && Accounts.Pass == password && Accounts.Status!="banned").FirstOrDefault();
                
                if (a1 == null)
                {
                    loginError.Content = "Ошибка: Неверный лоигн или пароль.";
                }
                else
                {
                    string role = a1.Role;
                    MainMenu mm = new MainMenu(login, role);

                    logMaker("Вход в аккаунт \""+login+"\".");

                    mm.Show();
                    this.Close();
                }
            }



        }

        public static void logMaker(string message)
        {
            using (StreamWriter sw = new StreamWriter(".log.txt", true))
            {
                sw.WriteLine(String.Format("{0}    {1}", DateTime.Now.ToString() + ":", message));
            }
        }

        
    }
}

