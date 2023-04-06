using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.PageFolder.ManagerPageFolder;
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

namespace CinemaNetworkApp.WindowFolder.ManagerWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        public ManagerMainWindow()
        {
            InitializeComponent();
        }


        //private void FilmsListBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new ListFilms());
        //}

        //private void FilmsAddBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Navigate(new AddFilm());
        //}

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.MBExit();
        }

        private void ListUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListEmployee());
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.MBLogOut(this);
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEmployee());
        }

        private void CinemaListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListCinema());
        }

        private void AddFilm_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddFilm());
        }

        private void ListTickets_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListFilms());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("Окно закрывается");
        }
    }
}
