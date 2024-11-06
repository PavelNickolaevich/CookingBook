using CulinaryBook.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.AppFrame.frMain.GoBack();
        }

        private void pswBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(pswBox.Password != pswBox2.Password)
            {
                regBtn.IsEnabled = false;
                pswBox2.Background = Brushes.LightCoral;
                pswBox2.BorderBrush = Brushes.Red;
            } 
            else
            {
                regBtn.IsEnabled = true;
                pswBox2.Background = Brushes.LightGreen;
                pswBox2.BorderBrush = Brushes.Green;

            }
        }

        private void regBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ApplicationData.AppConnect.culinaryEntities.Authors.Count(x => x.Login == loginTxt.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                      
                }
                if (String.IsNullOrEmpty(loginTxt.Text) || String.IsNullOrEmpty(authorTxt.Text) || String.IsNullOrEmpty(pswBox.Password) 
                    || String.IsNullOrWhiteSpace(pswBox.Password) 
                    || String.IsNullOrEmpty(pswBox2.Password)
                    || String.IsNullOrWhiteSpace(pswBox2.Password))
                {
                    MessageBox.Show("Не заполнены все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if(!String.IsNullOrEmpty(emailTxt.Text) && !CheckIsValidEmail(emailTxt.Text)) {
                    MessageBox.Show("Некорректный email", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (!String.IsNullOrEmpty(phoneTxt.Text) && !CheckIsValidPhoneNumber(phoneTxt.Text))
                {
                    MessageBox.Show("Некорректный телефон", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Authors author = new Authors()
                {
                    Login = loginTxt.Text,
                    AuthorName = authorTxt.Text,
                    Password = pswBox.Password,
                    Birth_of_date = datePicker.SelectedDate,
                    Email = emailTxt.Text,
                    Experience = Convert.ToInt32(expTxt.Text),
                    Phone = phoneTxt.Text

                };

                AppConnect.culinaryEntities.Authors.Add(author);
                AppConnect.culinaryEntities.SaveChanges();
                MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                ApplicationData.AppFrame.frMain.GoBack();
                

            }
            catch (Exception ex)
            {

            }
        }

        private bool CheckIsValidEmail(string email)
        {
            Regex regex = new Regex("r\"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$)\"");
            MatchCollection match = regex.Matches(email);
            return match.Count < 1 ? false : true;
        }

        private bool CheckIsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");
            MatchCollection match = regex.Matches(phoneNumber);
            return match.Count < 1 ? false : true;
        }
    }
}
