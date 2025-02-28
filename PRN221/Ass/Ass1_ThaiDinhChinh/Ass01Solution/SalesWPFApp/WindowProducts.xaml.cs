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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        public WindowProducts()
        {
            InitializeComponent();
            Loaded += ProductsLoad;
        }

        private void ProductsLoad(object sender, RoutedEventArgs e)
        {
            
        }

         
        private void btnaddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductPopup  popup = new ProductPopup();
            popup.Show();
        }

        private void btneditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btndeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnbackToMain_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main window or perform any other action
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
