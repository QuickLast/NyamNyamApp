using Nyam_Nyam.DB;
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

namespace Nyam_Nyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        public static List<Category> categories { get; set; }
        public static List<Dish> dishes { get; set; }
        public static Dish dish { get; set; }
        public static List<Ingredient> ingredients { get; set; }

        public IngredientsPage()
        {
            InitializeComponent();
            ingredients = DBConnection.nyamNyam.Ingredient.ToList();
            Refresh();
        }

        private void Refresh()
        {
            IngredientsLV.ItemsSource = DBConnection.nyamNyam.Ingredient.ToList();
        }

        //private void DishesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (IngredientsLV.SelectedItem is Ingredient)
        //    {
        //        DBConnection.selectedDish = IngredientsLV.SelectedItem as Ingredient;
        //        NavigationService.Navigate(new RecipeForSelectedDishPage(IngredientsLV.SelectedItem as Ingredient));
        //    }
        //}

        private void Hyperlink_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
        private void MinusBtn_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
        private void PlusBtn_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
    }
}
