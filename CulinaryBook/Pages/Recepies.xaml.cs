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

namespace CulinaryBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Recepies.xaml
    /// </summary>
    public partial class Recepies : Page
    {
        public Recepies()
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
            foreach( var item in category )
            {
                ComboFilter.Items.Add(item.Categories);
            }

        }

        Recipes[] RecepiesList()
        {
            try
            {
                List<Recipes> recipes = AppConnect.culinaryEntities.Recipes.ToList();
                if(TextSearch != null)
                {
                    recipes = recipes.Where(x => x.RecipeName.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }

                if(ComboFilter.SelectedIndex > 0)
                {
                    switch(ComboFilter.SelectedIndex)
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
                if(ComboSort.SelectedIndex > 0)
                {
                    switch(ComboSort.SelectedIndex)
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
                } else
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
    }
    
}
