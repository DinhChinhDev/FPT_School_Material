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
    /// Interaction logic for ManagerProductWindow.xaml
    /// </summary>
    public partial class ManagerProductWindow : Window
    {
        IProductRepository productRepository;
        public ManagerProductWindow(IProductRepository repository)
        {
            InitializeComponent();
            productRepository = repository;
        }

        public void LoadProductList()
        {
            lvProducts.ItemsSource = productRepository.GetProducts();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            insertProductWindow insertProductWindow = new insertProductWindow(productRepository, this);
            insertProductWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Insert Product");
                    return;
                }
                var myContextDB = new PRN221_As01Context();
                Product product = GetProductObjects();
                List<OrderDetail> orders = new List<OrderDetail>();
                orders = myContextDB.OrderDetails.Where(item => item.ProductId == product.ProductId).ToList();
                if (orders.Count != 0)
                {
                    MessageBox.Show($"{product.ProductName} had order , can't delete member", "Delete Member");
                }
                else
                {
                    productRepository.DeleteProduct(product);
                    this.LoadProductList();
                    MessageBox.Show($"{product.ProductName} deleted successfully ", "Delete Product");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            IOrderRepository orderRepository = new OrderRepository();
            var managerOrderWindow = new ManagerOrderWindow(orderRepository);
            managerOrderWindow.Show();
            this.Close();
            managerOrderWindow.LoadOrderList();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            IMemberRepository MemberRepository = new MemberRepository();
            var windowMember = new WindowManagerMembers(MemberRepository);
            windowMember.Show();
            this.Close();
            windowMember.LoadMemberList();
        }


        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!blankInput())
                {
                    MessageBox.Show("Blank input", "Update Product");
                    return;
                }
                Product product = GetProductObjects();
                UpdateProductWindow updateProductWindow = new UpdateProductWindow(productRepository, this, product);
                updateProductWindow.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var lstProduct = productRepository.GetProducts().ToList();
            var ProductId = String.IsNullOrEmpty(txtProductId.Text) == true ? "" : txtProductId.Text;
            var CategoryId = String.IsNullOrEmpty(txtCategoryId.Text) == true ? "" : txtCategoryId.Text;
            var ProductName = String.IsNullOrEmpty(txtProductName.Text) == true ? "" : txtProductName.Text;
            var Weight = String.IsNullOrEmpty(txtWeight.Text) == true ? "" : txtWeight.Text;
            var UnitPrice = String.IsNullOrEmpty(txtUnitPrice.Text) == true ? "" : txtUnitPrice.Text;
            var UnitsInStock = String.IsNullOrEmpty(txtUnitsInStock.Text) == true ? "" : txtUnitsInStock.Text;

            lstProduct = lstProduct.Where(x => (x.ProductId+"").ToLower().Contains(ProductId.ToLower())
               && (x.CategoryId + "").ToLower().Contains(CategoryId.ToLower())
               && x.ProductName.ToLower().Contains(ProductName.ToLower())
               && x.Weight.ToLower().Contains(Weight.ToLower())
               && (x.UnitPrice + "").ToLower().Contains(UnitPrice.ToLower())
               && (x.UnitsInStock + "").ToLower().Contains(UnitsInStock.ToLower())
               ).ToList();
            lvProducts.ItemsSource = lstProduct;
        }

        private void txtUnitsInStock_TextChanged()
        {

        }
    }
}
