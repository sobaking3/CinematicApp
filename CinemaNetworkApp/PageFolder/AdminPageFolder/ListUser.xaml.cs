
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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            ListUserDG.ItemsSource=DBEntities.GetContext()
                .User.ToList().OrderBy(u=>u.LoginUser);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListUserDG.ItemsSource=DBEntities.GetContext()
                    .User.Where(u=>u.LoginUser
                    .StartsWith(SearchTb.Text))
                    .ToList().OrderBy(u => u.LoginUser);
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void DeleteM1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = ListUserDG.SelectedItem as User;

                if(ListUserDG.SelectedItem == null)
                {
                    MBClass.ErrorMB("Пользователь не выбран");
                }
                else
                {
                    if (MBClass.QuestionMB($"Удалить пользователя " +
                    $"с логином {user.LoginUser}?"))
                    {
                        DBEntities.GetContext().User.Remove(ListUserDG.SelectedItem as User);
                        DBEntities.GetContext().SaveChanges();
                        MBClass.InfoMB("Пользователь удален");
                        ListUserDG.ItemsSource = DBEntities.GetContext()
                    .User.ToList().OrderBy(u => u.LoginUser);
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);      
            }
        }

        private void EditM1_Click(object sender, RoutedEventArgs e)
        {
            if(ListUserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя для " +
                    "редактирования!");
            }
            else
            {
                NavigationService.Navigate(
                    new EditUserPage(
                        ListUserDG.SelectedItem as User));
            }
        }
    }
}
