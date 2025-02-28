using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.DataAccess;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly AppUserRepository _userRepository;
        public Login()
        {
            InitializeComponent();
            _userRepository = new AppUserRepository(new DataAccess.Repository.AppDbContext());
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Password;
            var user = await _userRepository.GetFirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            if (user != null)
            {
                if (userName == "ad" && password == "123")
                {
                    Session.Role = "Admin";
                    Window_ window_ = new Window_();
                    window_.Show();
                    MessageBox.Show($"User: {userName}, Password: {password}");
                    Close();
                    return;
                }
                Session.Role = user.IsShipper ? "Shipper" : "User";
                Session.UserName = userName;
                Session.UserId = user.AppUserId;
                UserWindow1 userWindow = new UserWindow1();//
                userWindow.Show();
                Close();
                return;
            }
            MessageBox.Show("Incorrect username or password", "Login");
        }
    }
}
