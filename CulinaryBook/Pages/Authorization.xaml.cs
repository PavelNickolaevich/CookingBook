using CulinaryBook.ApplicationData;
using CulinaryBook.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace CulinaryBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
      
        public Authorization()
        {
            InitializeComponent();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.culinaryEntities.Authors.FirstOrDefault(x => x.Login == logTxtBox.Text && x.Password == passTxtBox.Password);
                if (userObj == null)
                {
                    MessageBox.Show(
                        "Такого пользователя нет",
                        "Ошибка при авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );
                } else
                {
                    //SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CulinaryBook;Integrated Security=True");
                    //SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CulinaryBook;Integrated Security=True");
                    //sqlConnection.Open();

                    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    //DataTable dataTable = new DataTable();
                    //string query = $"select * from Authors where Login='{logTxtBox.Text}' and Password='{passTxtBox.Password}'";
                    //SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
                    //sqlDataAdapter.SelectCommand = sqlCom;
                    //sqlDataAdapter.Fill(dataTable);

                    // if (dataTable.Rows.Count == 1)

                    var authorId = userObj.AuthorID;
            
                    User user = new User(authorId);

       

                    MessageBox.Show(
                  "Вы успешно вошли",
                   "Успешно",
                  MessageBoxButton.OK,
               MessageBoxImage.Information);

      
                    

                    NavigationService.Navigate(new Pages.Recepies(user));


                }

                //sqlConnection.Close();
                //NavigationService.Navigate(new Pages.Recepies());

                //}
            } catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка" + ex.Message.ToString() + "Критическая работа приложения",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );

            }
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Registration());
        }
    }
}
