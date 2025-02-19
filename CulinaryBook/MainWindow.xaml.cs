using CulinaryBook.ApplicationData;
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

namespace CulinaryBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            AppConnect.culinaryEntities = new CulinaryBookEntities2();
            ApplicationData.AppFrame.frMain = FrMain;
            FrMain.Navigate(new Pages.Authorization());
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void closeButton_Enter(object sender, MouseEventArgs e)
        {
            closeButton.Foreground = Brushes.Chocolate;
        }

        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeButton.Foreground = Brushes.Black;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.FrMain.Navigate(new Uri("Pages/Recepies.xaml", UriKind.Relative));
        }
    }
}
