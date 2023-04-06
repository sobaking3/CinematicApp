using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.DataFolder;
using CinemaNetworkApp.PageFolder.AdminPageFolder;
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

namespace CinemaNetworkApp.WindowFolder.AdminWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
            using(var context = new DBEntities())
            {
                var WorkerInfoId = 1;
                var employee = context.WorkerInfo.Where(e => e.
                IdInfoAbout == WorkerInfoId).FirstOrDefault();
                var fullName = employee.FirstName + "" + employee.LastName;
                EmpName.Text = fullName;
            }
        }

        private void ListUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListUserPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.MBExit();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddUserPage());
        }

        private void CinemaListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListCinema());
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
