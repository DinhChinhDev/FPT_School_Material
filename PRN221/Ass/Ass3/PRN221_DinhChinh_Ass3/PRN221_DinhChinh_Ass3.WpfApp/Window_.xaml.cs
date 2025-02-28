using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
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

namespace PRN221_DinhChinh_Ass3.WpfApp
{
    /// <summary>
    /// Interaction logic for Window_.xaml
    /// </summary>
    public partial class Window_ : Window
    {
        public Window_()
        {
            InitializeComponent();
            MainContent.Navigate(new UserManagement());
        }

        private void UserManagement_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new UserManagement());
        }

        private void BookManagement_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new BookManagement());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.Clear();
            Login test = new Login();
            test.Show();
            Close();
        }
    }
}
