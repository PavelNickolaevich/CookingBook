using CulinaryBook.ApplicationData;
using CulinaryBook.dto;
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
using System.Xml;

namespace CulinaryBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Recepies.xaml
    /// </summary>
    public partial class Recepies : Page
    {
        private User user;
        public Recepies(User user)
        {
            InitializeComponent();
            listProducts.ItemsSource = RecepiesList();
            ComboSort.Items.Add(" < Время > ");
            ComboSort.Items.Add(" < По возростанию времени приготовления > ");
            ComboSort.Items.Add(" < По убыванию времени выполнения > ");
            ComboSort.SelectedIndex = 0;
            ComboFilter.SelectedIndex = 0;
            var category = AppConnect.culinaryEntities.Recipes;
            ComboFilter.Items.Add("Категория");
            foreach (var item in category)
            {
                ComboFilter.Items.Add(item.Categories);
            }
            this.user = user;

        }

        Recipes[] RecepiesList()
        {
            try
            {
                List<Recipes> recipes = AppConnect.culinaryEntities.Recipes.ToList();
                if (TextSearch != null)
                {
                    recipes = recipes.Where(x => x.RecipeName.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }

                if (ComboFilter.SelectedIndex > 0)
                {
                    switch (ComboFilter.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.Where(x => x.CategoryID == 1).ToList();
                            break;
                        case 2:
                            recipes = recipes.Where(x => x.CategoryID == 2).ToList();
                            break;
                        case 3:
                            recipes = recipes.Where(x => x.CategoryID == 3).ToList();
                            break;
                        case 4:
                            recipes = recipes.Where(x => x.CategoryID == 4).ToList();
                            break;
                    }
                }
                if (ComboSort.SelectedIndex > 0)
                {
                    switch (ComboSort.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.OrderBy(x => x.CookingTime).ToList();
                            break;
                        case 2:
                            recipes = recipes.OrderByDescending(x => x.CookingTime).ToList();
                            break;

                    }
                }

                if (recipes.Count > 0)
                {
                    tbCounter.Text = "Найдено " + recipes.Count + " рец. ";
                }
                else
                {
                    tbCounter.Text = "Не найдено";
                }

                return recipes.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
                return null;

            }
        }


        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listProducts.ItemsSource = RecepiesList();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listProducts.ItemsSource = RecepiesList();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listProducts.ItemsSource = RecepiesList();
        }

        private void addNewRecepieBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddNewRecepie(user));

        }

        private void deleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var recipie = listProducts.SelectedItem as Recipes;
                if (recipie != null)
                {
                    AppConnect.culinaryEntities.Recipes.Remove(recipie);
                    AppConnect.culinaryEntities.SaveChanges();
                    RecepiesList().ToList().Remove(recipie);
                    NavigationService.Navigate(new Pages.Recepies(user));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении рецепта: " + ex.Message);
            }
        }

        private void updateRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var recipie = listProducts.SelectedItem as Recipes;
                if (recipie != null)
                {
                    NavigationService.Navigate(new Pages.AddNewRecepie(user, recipie));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении рецепта: " + ex.Message);


            }
        }
    }
    
}
