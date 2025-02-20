using CulinaryBook.ApplicationData;
using CulinaryBook.dto;
using CulinaryBook.Utills;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace CulinaryBook.Pages
{
    /// <summary>
    /// Interaction logic for AddNewRecepie.xaml
    /// </summary>
    public partial class AddNewRecepie : Page
    {
        private readonly User user;
        private Recipes updRecipie;
        public AddNewRecepie(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        public AddNewRecepie(User user, Recipes recipie)
        {
            InitializeComponent();
            this.user = user;
            updRecipie = recipie;
            txtRecipeName.Text = recipie.RecipeName;
            txtDescription.Text = recipie.Description;
            txtCookTime.Text = recipie.CookingTime.ToString();
            cmbCategory.Text = AppConnect.culinaryEntities.Categories.FirstOrDefault(c => c.CategoryID == recipie.CategoryID).CategoryName;

        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {

            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var imagePath = System.IO.Path.Combine(projectPath, "Images");
    
            OpenFileDialog openFileDialog = new OpenFileDialog

            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                InitialDirectory = imagePath,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath));
                imgRecipe.Source = bitmap;
                
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCategory = cmbCategory.SelectedItem as ComboBoxItem;
                string categoryName = selectedCategory.Content.ToString();
                var categoryID = AppConnect.culinaryEntities.Categories.FirstOrDefault(c => c.CategoryName == categoryName).CategoryID;

                int authorId = user.UserId;
                Recipes recepie = new Recipes()
                {
                    RecipeName = txtRecipeName.Text,
                    Description = txtDescription.Text,
                    CookingTime = Int32.Parse(txtCookTime.Text),
                    //Image = imgRecipe.
                    CategoryID = categoryID,
                    AuthorID = user.UserId
                };         

                if(updRecipie != null)
                {
                    updRecipie.RecipeName = txtRecipeName.Text;
                    updRecipie.Description = txtDescription.Text;
                    updRecipie.CookingTime = Int32.Parse(txtCookTime.Text);
                    updRecipie.CategoryID = categoryID;

                    AppConnect.culinaryEntities.SaveChanges();
                    Notification.SuccessfulNotify("Рецепт успешно обновлен");
              
                } else
                {
                    AppConnect.culinaryEntities.Recipes.Add(recepie);
                    AppConnect.culinaryEntities.SaveChanges();
                    Notification.SuccessfulNotify("Рецепт успешно добавлен");
                }
      
                NavigationService.Navigate(new Pages.Recepies(user));
            }
            catch (Exception ex)
            {
                Notification.FailurefulNotify($"Произошла непредвиденная ошибка: {ex.Message}");
                Logger.LogError(ex);
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Pages.Recepies(user));
        }

    }
}
