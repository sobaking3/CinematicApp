
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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = new User();
        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext=user;
            RoleCb.ItemsSource=DBEntities.GetContext()
                .Role.ToList();
            this.user.IdUser = user.IdUser;
        }

        private void SaveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user=DBEntities.GetContext().User.
                    FirstOrDefault(u=>u.IdUser==user.IdUser);
                user.LoginUser=LoginTb.Text;
                user.PasswordUser=PasswordPb.Text;
                user.IdRole=Int32.Parse
                    (RoleCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно сохранены");
                NavigationService.Navigate(new ListUserPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
