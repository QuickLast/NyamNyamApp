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
using Nyam_Nyam.Pages;

namespace Nyam_Nyam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            string pageUri = e.Uri.OriginalString;

            switch (pageUri)
            {
                case "DishesPage":
                    NaFr.Navigate(new Uri("Pages/DishesPage.xaml", UriKind.Relative));
                    break;
                case "IngredientsPage":
                    NaFr.Navigate(new Uri("Pages/IngredientsPage.xaml", UriKind.Relative));
                    break;
                default:
                    NaFr.Navigate(new Uri("Pages/OrdersPage.xaml", UriKind.Relative));
                    break;
            }
        }
    }
}
