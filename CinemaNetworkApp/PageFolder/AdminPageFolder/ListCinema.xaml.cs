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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaNetworkApp.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListCinema.xaml
    /// </summary>
    public partial class ListCinema : Page
    {
        public ListCinema()
        {
            InitializeComponent();
            ListCinemaLB.ItemsSource = DBEntities.GetContext()
                .Cinema.ToList().OrderBy(u => u.CinemaName);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListCinemaLB.ItemsSource = DBEntities.GetContext()
                    .Cinema.Where(s => s.CinemaName
                    .StartsWith(SearchTb.Text) || s.CinemaName
                    .StartsWith(SearchTb.Text))
                    .ToList().OrderBy(s => s.CinemaName);
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

    }
}
