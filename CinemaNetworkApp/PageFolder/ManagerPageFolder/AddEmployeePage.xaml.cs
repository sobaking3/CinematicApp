using Microsoft.Win32;
using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.DataFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using RagimovApp.ClassFolder;

namespace CinemaNetworkApp.PageFolder.ManagerPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        //WorkerInfo WorkerInfo = new WorkerInfo();
        //User user = new User();
        //public AddEmployeePage()
        //{
        //    InitializeComponent();
        //    RoleCb.ItemsSource = DBEntities.GetContext().Role.ToList();
        //}

        //private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        AddUser();
        //        WorkerInfoAdd();

        //        MBClass.InfoMB("Сотрудник добавлен");
        //    }
        //    catch(DbEntityValidationException ex)
        //    {
        //        MBClass.ErrorMB(ex);
        //    }
        //}

        //private void AddUser()
        //{
        //    var userAdd = new User()
        //    {
        //        LoginUser = LoginTb.Text,
        //        PasswordUser = PasswordPb.Text,
        //        IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
        //    };
        //    DBEntities.GetContext().User.Add(userAdd);
        //    DBEntities.GetContext().SaveChanges();
        //    user.IdUser = userAdd.IdUser;
        //}
        //private void WorkerInfoAdd()
        //{
        //    var WorkerInfoAdd = new WorkerInfo()
        //    {
        //        LastName = LastNameTb.Text,
        //        FirstName = FirstNameTb.Text,
        //        MiddleName = MiddleNameTb.Text,
        //        Number = NumberPhoneTb.Text,
        //        IdUser = user.IdUser,
        //        WorkerPhoto = !string.IsNullOrEmpty(selectedFileName) ? ImageClass.ConvertImageToByteArray(selectedFileName): null
        //    };
        //    DBEntities.GetContext().WorkerInfo.Add(WorkerInfoAdd);
        //    DBEntities.GetContext().SaveChanges();
        //}
        //string selectedFileName = "";

        //private void AddPhoto()
        //{
        //    try
        //    {
        //        OpenFileDialog op = new OpenFileDialog();
        //        op.InitialDirectory = "";
        //        op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        //            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        //            "Portable Network Graphic (*.png)|*.png";

        //        if (op.ShowDialog() == true)
        //        {
        //            selectedFileName = op.FileName;
        //            WorkerInfo.WorkerPhoto = ImageClass.ConvertImageToByteArray(selectedFileName);
        //            ImPhoto.Source = ImageClass.ConvertByteArrayToImage(WorkerInfo.WorkerPhoto);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MBClass.ErrorMB(ex);
        //    }
        //}

        //private void UploadImageBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    AddPhoto();
        //}
    }
}
