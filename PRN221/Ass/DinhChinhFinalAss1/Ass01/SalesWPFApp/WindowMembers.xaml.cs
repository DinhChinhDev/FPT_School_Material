using System.Windows;
using DataAccess;
using BusinessObject;
using System.Collections.Generic;
using DataAccess.Repository;

namespace SalesWPFApp
{
    public partial class WindowMembers : Window
    {
        private MemberDAO memberDAO = new MemberDAO(new MemberRepository());

        public WindowMembers()
        {
            InitializeComponent();
            LoadMembers();
        }

        // Load members from the database and display them in the DataGrid
        private void LoadMembers()
        {
            List<Member> members = new List<Member>(memberDAO.GetAllMembers());
            dgMembers.ItemsSource = members;
        }

        // Add Member
        private void BtnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if (IsFormValid())
            {
                Member newMember = new Member
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Password
                };

                memberDAO.AddMember(newMember);
                LoadMembers();
                ClearForm();
                MessageBox.Show("Member added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Update Member
        private void BtnUpdateMember_Click(object sender, RoutedEventArgs e)
        {
            if (dgMembers.SelectedItem is Member selectedMember && IsFormValid())
            {
                selectedMember.Email = txtEmail.Text;
                selectedMember.CompanyName = txtCompanyName.Text;
                selectedMember.City = txtCity.Text;
                selectedMember.Country = txtCountry.Text;
                selectedMember.Password = txtPassword.Password;

                memberDAO.UpdateMember(selectedMember);
                LoadMembers();
                ClearForm();
                MessageBox.Show("Member updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a member to update.", "Update Member", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Delete Member
        private void BtnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (dgMembers.SelectedItem is Member selectedMember)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedMember.Email}?",
                                                          "Delete Member", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    memberDAO.DeleteMember(selectedMember.MemberId);
                    LoadMembers(); // Reload the members after deletion
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.", "Delete Member", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Clear the form inputs
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        // Populate the form fields when a member is selected in the DataGrid
        private void DgMembers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgMembers.SelectedItem is Member selectedMember)
            {
                txtEmail.Text = selectedMember.Email;
                txtCompanyName.Text = selectedMember.CompanyName;
                txtCity.Text = selectedMember.City;
                txtCountry.Text = selectedMember.Country;
                txtPassword.Password = selectedMember.Password;
            }
        }

        // Validate the form input
        private bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text) || string.IsNullOrWhiteSpace(txtCountry.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        // Clear form fields
        private void ClearForm()
        {
            txtEmail.Clear();
            txtCompanyName.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtPassword.Clear();
            dgMembers.SelectedItem = null;
        }
    }
}
