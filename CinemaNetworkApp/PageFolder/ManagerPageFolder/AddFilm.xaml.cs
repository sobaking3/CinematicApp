using CinemaNetworkApp.ClassFolder;
using CinemaNetworkApp.DataFolder;
using Microsoft.Win32;
using RagimovApp.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Xml;

namespace CinemaNetworkApp.PageFolder.ManagerPageFolder
{

    public partial class AddFilm : Page
    {
        Films Films = new Films();
        public AddFilm()
        {
            InitializeComponent();

        }

        private void AddFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilmInfoAdd();

                MBClass.InfoMB("Фильм добавлен");
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
        private void FilmInfoAdd()
        {
            
            var FilmInfoAdd = new Films()
            {
                FilmName = FilmNameTb.Text,
                DateOfIssue = DatePickerTb.SelectedDate.Value,
                FilmDirector = FilmDirectorTb.Text,
                Rating = Convert.ToDecimal(FilmRateTb.Text),
                AgeLimit = Convert.ToInt32(AgeLimitTb.Text),
                Duration = DurationTP.Text,
            FilmPoster = !string.IsNullOrEmpty(selectedFileName) ? ImageClass.ConvertImageToByteArray(selectedFileName) : null
            };
            DBEntities.GetContext().Films.Add(FilmInfoAdd);
            DBEntities.GetContext().SaveChanges();
        }
        string selectedFileName = "";

        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    Films.FilmPoster = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PosterPhoto.Source = ImageClass.ConvertByteArrayToImage(Films.FilmPoster);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
        private void AddImgBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
    }
}
