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
    /// Interaction logic for insertProductWindow.xaml
    /// </summary>
    public partial class insertProductWindow : Window
    {
        IProductRepository productRepository;
        ManagerProductWindow managerProductWindow;
        public insertProductWindow(IProductRepository repository, ManagerProductWindow wmm)
        {
            InitializeComponent();
            productRepository = repository;
            managerProductWindow = wmm;
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

        private bool blankInput()
        {
            if (txtCategoryId.Text.Length < 1 || txtProductId.Text.Length < 1 || txtProductName.Text.Length < 1
                || txtUnitPrice.Text.Length < 1 || txtUnitsInStock.Text.Length < 1 || txtWeight.Text.Length < 1) return false;
            return true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert Product");
                    return;
                }
                Product product = GetProductObjects();
                productRepository.InsertProduct(product);
                this.Close();
                managerProductWindow.LoadProductList();
                MessageBox.Show($"{product.ProductName} inserted successfully ", "Insert Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }
    }
}
