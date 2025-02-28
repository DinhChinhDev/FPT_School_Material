using System.Windows;
using DataAccess;
using DataAccess.Repository;

namespace SalesWPFApp
{
    public partial class WindowLogin : Window
    {
        private MemberDAO memberDAO = new MemberDAO(new MemberRepository());

        public WindowLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            // Authenticate the user
            var member = memberDAO.AuthenMember(email, password);

            if (member != null)
            {
                // Successful login
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // You can now navigate to the main window of your application.
                MainWindow mainWindow;
                if (email.Equals("admin@gmail.com"))
                {
                    mainWindow = new MainWindow(true);
                } else
                {
                    mainWindow = new MainWindow(false);
                }
                MySession.LoggedInMemberId = member.MemberId;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
