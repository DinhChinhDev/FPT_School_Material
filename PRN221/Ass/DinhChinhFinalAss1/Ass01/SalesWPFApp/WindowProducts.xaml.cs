using System.Windows;
using BusinessObject;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using DataAccess;

namespace SalesWPFApp
{
    public partial class WindowProducts : Window
    {
        private readonly ProductDAO _productDAO;
        private Product selectedProduct;

        public WindowProducts()
        {
            InitializeComponent();
            _productDAO = new ProductDAO(new ProductRepository());
            LoadProducts();
        }

        // Load all products and display in the DataGrid
        private void LoadProducts()
        {
            List<Product> products = _productDAO.GetAllProducts().ToList();
            dgProducts.ItemsSource = products;
        }

        // When a product is selected in the DataGrid, display its details in the textboxes
        private void DgProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProduct = dgProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                txtProductName.Text = selectedProduct.ProductName;
                txtCategoryId.Text = selectedProduct.CategoryId.ToString();
                txtWeight.Text = selectedProduct.Weight;
                txtUnitPrice.Text = selectedProduct.UnitPrice.ToString();
                txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
            }
        }

        // Add a new product
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                ProductName = txtProductName.Text,
                CategoryId = int.Parse(txtCategoryId.Text),
                Weight = txtWeight.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitsInStock.Text)
            };

            _productDAO.AddProduct(newProduct);
            LoadProducts(); // Reload the product list
        }

        // Update the selected product
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                selectedProduct.ProductName = txtProductName.Text;
                selectedProduct.CategoryId = int.Parse(txtCategoryId.Text);
                selectedProduct.Weight = txtWeight.Text;
                selectedProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                selectedProduct.UnitsInStock = int.Parse(txtUnitsInStock.Text);

                _productDAO.UpdateProduct(selectedProduct);
                LoadProducts(); // Reload the product list
            }
        }

        // Delete the selected product
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                _productDAO.DeleteProduct(selectedProduct.ProductId);
                LoadProducts(); // Reload the product list
            }
        }
    }
}
