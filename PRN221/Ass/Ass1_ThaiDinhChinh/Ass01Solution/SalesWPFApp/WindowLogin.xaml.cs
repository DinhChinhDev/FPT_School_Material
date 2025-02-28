using BusinessObject;
using DataAccess;
using DataAccess.Repository;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly MemberObject memberObject;
        public WindowLogin()
        {
            InitializeComponent();
            memberObject = new MemberObject();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please input all fields!");
            }
            bool isAuthorized = memberObject.Login(txtEmail.Text, txtPassword.Password);
            if (isAuthorized)
            {
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                MainWindow window1 = new MainWindow();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed! Passwoed or mail incorrect!");
            }

        }
    }
}
