using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CulinaryBook.Utills
{
     class Notification
    {
        public static void successfulNotify(string message)
        {
            MessageBox.Show(
                 message,
                 "Уведомление",
                 MessageBoxButton.OK,
                 MessageBoxImage.Information
                 );
        }

        public static void failurefulNotify(string message)
        { 
        MessageBox.Show(
                    message,
                    "Ошибка в добавлении рецепта",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
    }
}
