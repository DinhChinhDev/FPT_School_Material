using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace PRN221_DinhChinh_Ass3.WpfApp
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        public readonly AppUserRepository _userRepository;
        public UserManagement()
        {
            var _db = new AppDbContext();
            InitializeComponent();
            _userRepository = new AppUserRepository(_db);
            LoadData();
        }

        private async void LoadData()
        {
            dgvUsers.ItemsSource = await _userRepository.GetAllAsync();
        }
        private void dgvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = (AppUser)dgvUsers.SelectedItem;
            if (user == null) return;
            txtId.Text = user.AppUserId.ToString();
            txtUsername.Text = user.UserName;
            txtPassword.Password = user.Password;
            //txtId.IsEnabled = false;
            checkIsShipper.IsChecked = user.IsShipper;

            if (txtId.Text != string.Empty)
            {
                btnDelete.IsEnabled = true;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Password = string.Empty;
            checkIsShipper.IsChecked = false;
            btnDelete.IsEnabled = false;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate input before saving
            if (!ValidateForm())
            {
                return; // Stop if validation fails
            }
            if (txtId.Text != string.Empty)
            {
                // Update
                var user = await _userRepository.GetFirstOrDefaultAsync(x => x.AppUserId == int.Parse(txtId.Text));
               
                user.UserName = txtUsername.Text;
                user.IsShipper = (bool)checkIsShipper.IsChecked;
                user.Password = txtPassword.Password;

                _userRepository.Update(user);
                await _userRepository.SaveChangeAsync();
                MessageBox.Show("User updated", "Update User");
            }
            else
            {
                // Add
                var user = new AppUser();
                user.UserName = txtUsername.Text;
                user.IsShipper = (bool)checkIsShipper.IsChecked;
                user.Password = txtPassword.Password;

                _userRepository.Add(user);
                await _userRepository.SaveChangeAsync();
                MessageBox.Show("User added", "Add User");
            }
            LoadData();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(x => x.AppUserId == int.Parse(txtId.Text));
            _userRepository.Delete(user);
            await _userRepository.SaveChangeAsync();
            MessageBox.Show("User deleted", "Delete User");
            LoadData();
        }


        private void dgvUsers_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                btnDelete.IsEnabled = false;
            }
        }
        private void btnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Visibility == Visibility.Visible)
            {
                // Show password in TextBox and hide PasswordBox
                txtPasswordReveal.Text = txtPassword.Password;
                txtPassword.Visibility = Visibility.Collapsed;
                txtPasswordReveal.Visibility = Visibility.Visible;
                btnShowPassword.Content = "🙈"; // Icon for hiding
            }
            else
            {
                // Hide password in TextBox and show PasswordBox
                txtPassword.Password = txtPasswordReveal.Text;
                txtPassword.Visibility = Visibility.Visible;
                txtPasswordReveal.Visibility = Visibility.Collapsed;
                btnShowPassword.Content = "👁"; // Icon for revealing
            }
        }

        // Sync PasswordBox content to TextBox for revealing
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordReveal.Text = txtPassword.Password;
        }
        private bool ValidateForm()
        {
            // Check for required fields


            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }

            // Additional validation (optional)
            if (txtPassword.Password.Length < 3)
            {
                MessageBox.Show("Password must be at least 3 characters long.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }
    }
}
