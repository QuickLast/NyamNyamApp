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
using Microsoft.Graphics.Canvas.Effects;
using Nyam_Nyam.DB;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;

namespace Nyam_Nyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для DishesPage.xaml
    /// </summary>
    public partial class DishesPage : Page
    {
        public static List<Category> categories { get; set; }
        public static List<Dish> dishes { get; set; }
        public static Dish dish { get; set; }

        public DishesPage()
        {
            InitializeComponent();
            categories = DBConnection.nyamNyam.Category.ToList();
            dishes = DBConnection.nyamNyam.Dish.ToList();

            this.DataContext = this;

            double max = dishes[0].FinalPriceInCents;
            double min = dishes[0].FinalPriceInCents;
            foreach (Dish dish in dishes)
            {
                if (dish.FinalPriceInCents > max)
                {
                    max = dish.FinalPriceInCents;
                }
                if (dish.FinalPriceInCents < min)
                {
                    min = dish.FinalPriceInCents;
                }
            }
            CostSlider.Maximum = max;
            CostSlider.Minimum = min;
            CostSlider.Value = max;

            Refresh();
        }

        private void Refresh()
        {
            var a = CategoryCB.SelectedItem as Category;
            var sorted = DBConnection.nyamNyam.Dish.ToList();
            if (AvailableChBx.IsChecked == false)
            {
                if (SearchTB.Text.Length == 0 && (a == null || a.Name == "Show All"))
                {
                    sorted = sorted;
                }
                else if (SearchTB.Text.Length != 0 && (a == null || a.Name == "Show All"))
                {
                    sorted = sorted.Where(i => i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower())).ToList();
                }
                else if (SearchTB.Text.Length == 0 && (a != null || a.Name != "Show All"))
                {
                    sorted = sorted.Where(i => i.CategoryId == a.Id).ToList();
                }
                else if (SearchTB.Text.Length != 0 && (a != null || a.Name != "Show All"))
                {
                    sorted = sorted.Where(i => i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) && i.CategoryId == a.Id).ToList();
                }
                sorted = sorted.Where(i => i.FinalPriceInCents <= CostSlider.Value).ToList();

                DishesLV.ItemsSource = sorted;
                return;
            }
            else if (AvailableChBx.IsChecked == true)
            {
                if (SearchTB.Text.Length == 0 && (a == null || a.Name == "Show All"))
                {
                    sorted = sorted.Where(i => i.Available == 1).ToList();
                }
                else if (SearchTB.Text.Length != 0 && (a == null || a.Name == "Show All"))
                {
                    sorted = sorted.Where(i => i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) && i.Available == 1).ToList();
                }
                else if (SearchTB.Text.Length == 0 && (a != null || a.Name != "Show All"))
                {
                    sorted = sorted.Where(i => i.CategoryId == a.Id && i.Available == 1).ToList();
                }
                else if (SearchTB.Text.Length != 0 && (a != null || a.Name != "Show All"))
                {
                    sorted = sorted.Where(i => i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) && i.Available == 1 && i.CategoryId == a.Id).ToList();
                };
                sorted = sorted.Where(i => i.FinalPriceInCents <= CostSlider.Value).ToList();

                DishesLV.ItemsSource = sorted;
            }
        }

        private void DishesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DishesLV.SelectedItem is Dish)
            {
                DBConnection.selectedDish = DishesLV.SelectedItem as Dish;
                NavigationService.Navigate(new RecipeForSelectedDishPage(DishesLV.SelectedItem as Dish));
            }
        }

        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AvailableChBx_Checked(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void CostSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Refresh();
        }
    } 
}
