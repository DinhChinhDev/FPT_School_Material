using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
       
        }

        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {
            WindowMembers window = new WindowMembers();
            window.Show();
            Close();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders window = new WindowOrders();
            window.Show();
            Close();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts window = new WindowProducts();
            window.Show();
            Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin window = new WindowLogin();
            Close();
        }
    }
}