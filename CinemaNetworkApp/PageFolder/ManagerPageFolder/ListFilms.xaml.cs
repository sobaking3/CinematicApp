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

namespace CinemaNetworkApp.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListFilms.xaml
    /// </summary>
    public partial class ListFilms : Page
    {
        public ListFilms()
        {
            InitializeComponent();
            ListFilmsLB.ItemsSource = DBEntities.GetContext()
                .Films.ToList().OrderBy(u => u.FilmName);
        }

        private void DeleteM1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Films Films = ListFilmsLB.SelectedItem as Films;

                if (ListFilmsLB.SelectedItem == null)
                {
                    MBClass.ErrorMB("Пользователь не выбран");
                }
                else
                {
                    if (MBClass.QuestionMB($"Удалить фильм " +
                    $"с названием {Films.FilmName}?"))
                    {
                        DBEntities.GetContext().Films.Remove(ListFilmsLB.SelectedItem as Films);
                        DBEntities.GetContext().SaveChanges();
                        MBClass.InfoMB("Фильм удален");
                        ListFilmsLB.ItemsSource = DBEntities.GetContext()
                    .Films.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListFilmsLB.ItemsSource = DBEntities.GetContext()
                    .Films.Where(s => s.FilmName
                    .StartsWith(SearchTb.Text) || s.FilmName
                    .StartsWith(SearchTb.Text) || s.FilmDirector
                    .StartsWith(SearchTb.Text))
                    .ToList().OrderBy(s => s.FilmName);
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
