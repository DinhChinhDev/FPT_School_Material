using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PRN221_DinhChinh_Ass3.WpfApp
{
    public partial class UserWindow : Window
    {
        private readonly BookRepository bookRepository;
        private readonly CategoryRepository categoryRepository;

        public UserWindow()
        {
            var _db = new AppDbContext();
            InitializeComponent();
            bookRepository = new BookRepository(_db);
            categoryRepository = new CategoryRepository(_db);
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

            // Add fetched categories to the list
            categoryList.AddRange(categories);

            cboCategory.ItemsSource = categoryList;
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedIndex = 0;
        }

        private void dgvBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvBooks.SelectedItem is Book selectedBook)
            {
                BookDetailWindow detailWindow = new BookDetailWindow(selectedBook);
                detailWindow.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FilterBooks();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterBooks();
        }

        private void dgvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterBooks();
        }

        private async void FilterBooks()
        {
            var searchText = txtSearch.Text.ToLower();
            var selectedCategoryId = ((Category)cboCategory.SelectedItem).CategoryId;

            // Apply search and category filters
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.Clear();
            Login test = new Login();
            test.Show();
            Close();
        }

        private void cboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterBooks();
        }


    }
}
