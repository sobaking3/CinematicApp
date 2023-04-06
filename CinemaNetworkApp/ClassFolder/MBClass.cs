using CinemaNetworkApp.WindowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace CinemaNetworkApp.ClassFolder
{
    public class MBClass
    {
        public static void ErrorMB(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void InfoMB(string text)
        {
            bool? result = new MessageBoxCustom(text, 
                MessageType.Info, MessageButtons.Ok).ShowDialog(); 
        }
        public static bool QuestionMB(string text)
        {
            return MessageBoxResult.Yes == MessageBox.Show(text, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
        public static void MBExit()
        {
            bool? Result = new MessageBoxCustom("Вы уверены, что хотите выйти? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                Application.Current.Shutdown();
            }
        }
        public static void MBLogOut(Window window)
        {
            bool? result = new MessageBoxCustom("Вы хотите выйти из аккаунта?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result == true)
            {
                Authorization loginWindow = new Authorization();
                window.Close();
                loginWindow.Show();
            }
        }
    }
}
