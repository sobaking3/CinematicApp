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
using System.Windows.Threading;
using CinemaNetworkApp.ClassFolder;

namespace CinemaNetworkApp.WindowFolder.LoadingFolder
{
    /// <summary>
    /// Логика взаимодействия для LoadingView.xaml
    /// </summary>
    public partial class LoadingView : Window
    {
        private Random rnd;
        private List<string> facts;
        private Queue<string> states;
        Updater _updater = new Updater();
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_updater.CheckNewVersion())
            {
                if (MBClass.QuestionMB("Обнаружена новая версия, обновить?") == true)
                {
                    if (_updater.HasUpdateZip())
                    {
                        _updater.Update();
                        App.Current.Shutdown();
                    }
                    else
                    {
                        MBClass.ErrorMB("Файл обновления не найден!");
                    }
                }
            }
            LoadFacts();
            LoadStates();

            CreateProgressTimer();
            CreateFactDispatcherTime();
            CreateStateDispatcherTime();
        }

        public LoadingView()
        {
            
            InitializeComponent();
            MessageBox.Show("Ямайка");
            DataContext = this;

            rnd = new Random();

           
        }

        private void CreateStateDispatcherTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += timer_Tick3;
            timer.Start();
            timer_Tick3(null, null);
        }

        private void timer_Tick3(object sender, EventArgs e)
        {
            if (states.Count > 1)
            {
                StateTextBlock.Text = states.Dequeue();
            }
            else
            {
                ((DispatcherTimer)sender)?.Stop();
            }
        }

        private void LoadStates()
        {
            states = new Queue<string>();
            states.Enqueue("Проверка файлов системы..");
            states.Enqueue("Загрузка базы данных...");
            states.Enqueue("Проверка данных...");
            states.Enqueue("Соеденение с сервером...");
        }

        private void CreateFactDispatcherTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += timer_Tick2;
            timer.Start();
            timer_Tick2(null, null);
        }

        private void timer_Tick2(object sender, EventArgs e)
        {
            FactTextBlock.Text = facts[rnd.Next(0, facts.Count)];
        }

        private void LoadFacts()
        {
            facts = new List<string>();
            facts.Add("90% курсовых работ в России покупные, неожиданно");
            facts.Add("Арнольд Шварценеггер, исполняя роль Терминатора, решил вовсе не моргать в фильме, так как считал, что роботы не могут этого делать");
            facts.Add("Рекорд по количеству скрытой рекламы принадлежит фильму «Железный человек». В нем она встречалась 64 раза");
            facts.Add("Вы знали, что эта загрузка явялется «Иллюзией обмана 2». Ну, фильм такой из 2к16");
        }

        private void CreateProgressTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
            timer_Tick(null, null);
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            FakeProgress.Value += rnd.NextDouble();
            if (FakeProgress.Value >= FakeProgress.Maximum)
            {
                ((DispatcherTimer)sender)?.Stop();
                StateTextBlock.Text = "Готово!";
                states.Clear();
                await Task.Delay(100);
                await Task.Run(() =>
                {

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        //System.Threading.Thread.Sleep(1500);


                        //System.Threading.Thread.Sleep(1000);

                        Hide();
                        new Authorization().Show();
                        Close();
                    });
                });

            }

        }


    }
}
