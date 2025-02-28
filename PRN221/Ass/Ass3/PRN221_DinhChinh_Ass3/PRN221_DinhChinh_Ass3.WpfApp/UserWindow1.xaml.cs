using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net;
using System.Printing;

namespace PRN221_DinhChinh_Ass3.WpfApp
{
    public partial class UserWindow1 : Window
    {
        private readonly BookRepository bookRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly ShipRepository shipRepository;
        private Book selectedBook;
        private HubConnection _hubConnection;

        public UserWindow1()
        {
            var _db = new AppDbContext();
            InitializeComponent();
            bookRepository = new BookRepository(_db);
            categoryRepository = new CategoryRepository(_db);
            shipRepository = new ShipRepository(_db);
            LoadData();
            
        }

        private async void LoadData()
        {
            // Load books and categories initially
            var books = await bookRepository.GetAllAsync(includeProperties: "Category");
            dgvBooks.ItemsSource = books;

            var categories = await categoryRepository.GetAllAsync();
            var categoryList = new List<Category>
            {
                new Category { CategoryId = -1, CategoryName = "All Categories" }
            };
            categoryList.AddRange(categories);
            cboCategory.ItemsSource = categoryList;
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedIndex = 0;
        }

        private void dgvBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvBooks.SelectedItem is Book book)
            {
                selectedBook = book;
                btnOrder.IsEnabled = true; // Enable Order button when a book is selected
            }
        }

        //private async Task dgvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        //{
        //    // Lấy dữ liệu từ hàng được chọn trong DataGrid
        //    var selectedBook = dgvBooks.SelectedItem as Book;

        //    // Kiểm tra xem có sách nào được chọn hay không
        //    if (selectedBook != null)
        //    {
        //        // Tạo đối tượng Ship mới dựa trên sách được chọn
        //        var ship = new Ship
        //        {
        //            BookId = selectedBook.BookId,
        //            DateOrder = DateTime.Now,
        //            UserOrderId = Session.UserId
        //        };

        //        // Thêm đối tượng ship vào cơ sở dữ liệu
        //        shipRepository.Add(ship);

        //        await shipRepository.SaveChangeAsync();

        //    }
        //}

        private void dgvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvBooks.SelectedItem is Book selectedBook)
            {
                // Gán sách được chọn vào biến `selectedBook`
                this.selectedBook = selectedBook;
                btnOrder.IsEnabled = true; // Kích hoạt nút Order khi có sách được chọn
            }
            else
            {
                btnOrder.IsEnabled = false; // Vô hiệu hóa nút Order khi không có sách nào được chọn
            }
        }

        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgvBooks.SelectedItem is Book book)
            {
                var ship = new Ship();
                ship.BookId = book.BookId;
                ship.DateOrder = DateTime.Now;
                ship.UserOrderId = Session.UserId;
                //ship.UserOrderId = 
                shipRepository.Add(ship);
                await shipRepository.SaveChangeAsync();
                MessageBox.Show($"Order placed for {selectedBook.BookName}");
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.Clear();
            Login loginWindow = new Login();
            loginWindow.Show();
            Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterBooks();
        }

        private async void FilterBooks()
        {
            var searchText = txtSearch.Text.ToLower();
            var selectedCategoryId = ((Category)cboCategory.SelectedItem).CategoryId;
            var books = await bookRepository.GetAllAsync(includeProperties: "Category");

            if (!string.IsNullOrEmpty(searchText))
            {
                books = books.Where(b =>
                    b.BookName.ToLower().Contains(searchText) ||
                    (b.Category != null && b.Category.CategoryName.ToLower().Contains(searchText))
                ).ToList();
            }
            if (selectedCategoryId != -1)
            {
                books = books.Where(b => b.CategoryId == selectedCategoryId).ToList();
            }

            dgvBooks.ItemsSource = books;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) FilterBooks();
        }

        private void cboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterBooks();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterBooks();
        }
    }
}