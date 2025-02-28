using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using Microsoft.AspNetCore.SignalR.Client;
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
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : Page
    {
        private readonly BookRepository _bookRepository;
        private readonly CategoryRepository _cateogyRepository;
        private HubConnection _hubConnection;
        public BookManagement()
        {
            var _db = new AppDbContext();
            InitializeComponent();
            _bookRepository = new BookRepository(_db);
            _cateogyRepository = new CategoryRepository(_db);
            LoadData();
            //ConnectToSignalR();
        }
        private async void ConnectToSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44347/bookHub")
                .Build();

            await _hubConnection.StartAsync();
        }
        private async void LoadData()
        {
            dgvBooks.ItemsSource = await _bookRepository.GetAllAsync(includeProperties: "Category");
            cboCategory.ItemsSource = await _cateogyRepository.GetAllAsync();
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedIndex = 0;
            //await _bookRepository.SaveChangeAsync();
        }
        private void dgvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var book = (Book)dgvBooks.SelectedItem;
            if(book == null) return;
            txtId.Text = book.BookId.ToString();
            txtName.Text = book.BookName;
            txtPrice.Text = book.Price.ToString();
            var index = cboCategory.Items.IndexOf(book.Category);
            cboCategory.SelectedIndex = index;
            if (txtId.Text != string.Empty)
            {
                btnDelete.IsEnabled = true;
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            //txtBookname.Text = string.Empty;
            cboCategory.SelectedIndex = 0;
            txtPrice.Text = string.Empty;
            btnDelete.IsEnabled = false;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate form before proceeding with save
            if (!ValidateForm())
            {
                return; // Stop if validation fails
            }
            if (txtId.Text != string.Empty)
            {
                // Update
                var book = await _bookRepository.GetFirstOrDefaultAsync(x => x.BookId == int.Parse(txtId.Text));
                book.BookName = txtName.Text;
                book.Price = double.Parse(txtPrice.Text);
                book.CategoryId = ((Category)cboCategory.SelectedItem).CategoryId;
                _bookRepository.Update(book);
                await _bookRepository.SaveChangeAsync();
                MessageBox.Show("Book updated", "Update Book");
            }
            else
            {
                // Add
                var book = new Book();
                book.BookName = txtName.Text;
                book.Price = double.Parse(txtPrice.Text);
                book.CategoryId = ((Category)cboCategory.SelectedItem).CategoryId;
                _bookRepository.Add(book);
                await _bookRepository.SaveChangeAsync();
                await _hubConnection.InvokeAsync("NotifyNewBook", book.BookName);
                MessageBox.Show("Book added", "Add Book");
            }
            LoadData();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var user = await _bookRepository.GetFirstOrDefaultAsync(x => x.BookId == int.Parse(txtId.Text));
            _bookRepository.Delete(user);
            await _bookRepository.SaveChangeAsync();
            MessageBox.Show("Book deleted", "Delete Book");
            LoadData();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                btnDelete.IsEnabled = false;
            }
        }

        private bool ValidateForm()
        {
            // Check if Name is empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return false;
            }

            // Check if Price is a valid positive number
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !double.TryParse(txtPrice.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPrice.Focus();
                return false;
            }

            // Check if a Category is selected
            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cboCategory.Focus();
                return false;
            }

            return true;
        }


        private void dgvBooks_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
