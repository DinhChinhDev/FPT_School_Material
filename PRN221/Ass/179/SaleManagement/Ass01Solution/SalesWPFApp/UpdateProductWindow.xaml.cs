using BusinessObject.Models;
using BusinessObject.Repository;
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
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        IProductRepository ProductRepository;
        ManagerProductWindow managerProductWindow;
        Product product;
        public UpdateProductWindow(IProductRepository repository, ManagerProductWindow wmm, Product products)
        {
            InitializeComponent();
            ProductRepository = repository;
            managerProductWindow = wmm;
            product = products;
            txtProductId.Text = "" + products.ProductId;
            txtCategoryId.Text = "" + products.CategoryId;
            txtProductName.Text = products.ProductName;
            txtWeight.Text = products.Weight;
            txtUnitPrice.Text = "" + products.UnitPrice;
            txtUnitsInStock.Text = "" + products.UnitsInStock;

        }
        private Product GetProductObjects()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Product");
            }

            return product;
        }

        public UpdateProductWindow()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product products = GetProductObjects();
                ProductRepository.UpdateProduct(products);
                this.Close();
                managerProductWindow.LoadProductList();
                MessageBox.Show($"{product.ProductName} updated successfully ", "Update Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

    }
}
