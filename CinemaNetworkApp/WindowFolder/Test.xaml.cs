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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }
        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            bool[,] seats = new bool[10, 10];
            Button button = (Button)sender;
            string[] parts = button.Name.Split('_');
            int row = int.Parse(parts[1]);
            int column = int.Parse(parts[2]);
            bool isTaken = seats[row, column];
            if (isTaken)
            {
                // Место уже занято, ничего не делаем
                return;
            }
            // Обновляем модель данных
            seats[row, column] = true;
            // Отмечаем кнопку как выбранную
            button.Background = Brushes.Green;
        }
    }
}
