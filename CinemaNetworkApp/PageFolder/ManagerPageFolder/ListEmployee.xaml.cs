using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace CinemaNetworkApp.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Page
    {
        public ListEmployee()
        {
            InitializeComponent();
            ListEmployeeLB.ItemsSource = DBEntities.GetContext()
            .WorkerInfo.Where(u => u.User.Role.NameRole != "Директор" && u.User.Role.NameRole != "Администратор")
            .ToList().OrderBy(u => u.LastName);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListEmployeeLB.ItemsSource = DBEntities.GetContext()
                    .WorkerInfo.Where(s => s.LastName
                    .StartsWith(SearchTb.Text) || s.FirstName
                    .StartsWith(SearchTb.Text) || s.Number
                    .StartsWith(SearchTb.Text))
                    .ToList().OrderBy(s => s.LastName);
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
                WorkerInfo WorkerInfo = ListEmployeeLB.SelectedItem as WorkerInfo;

                if (ListEmployeeLB.SelectedItem == null)
                {
                    MBClass.ErrorMB("Пользователь не выбран");
                }
                else
                {
                    if (MBClass.QuestionMB($"Удалить пользователя " +
                    $"с Фамилией {WorkerInfo.LastName}?"))
                    {
                        DBEntities.GetContext().WorkerInfo.Remove(ListEmployeeLB.SelectedItem as WorkerInfo);
                        DBEntities.GetContext().SaveChanges();
                        MBClass.InfoMB("Пользователь удален");
                        ListEmployeeLB.ItemsSource = DBEntities.GetContext()
                    .User.ToList().OrderBy(s => s.IdRole);
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
