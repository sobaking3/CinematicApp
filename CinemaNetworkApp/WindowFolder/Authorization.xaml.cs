using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.DataFolder;
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

namespace CinemaNetworkApp.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (string.IsNullOrEmpty(PasswordPb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.LoginUser == LoginTb.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Пароль или логин введен неверно");

                        LoginTb.Focus();

                    }
                    else if (user.PasswordUser != PasswordPb.Password)
                    {
                        MBClass.ErrorMB("Пароль или логин введен неверно");
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                MBClass.InfoMB("Администратор");
                                new AdminWindowFolder.AdminMainWindow().ShowDialog();
                                Hide();
                                break;
                            case 2:
                                MBClass.InfoMB("Менеджер");
                                new ManagerWindowFolder.ManagerMainWindow().ShowDialog();
                                Hide();
                                break;

                        }                    
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
