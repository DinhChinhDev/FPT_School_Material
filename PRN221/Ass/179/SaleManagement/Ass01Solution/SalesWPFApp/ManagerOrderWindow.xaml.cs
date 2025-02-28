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
    /// Interaction logic for ManagerOrderWindow.xaml
    /// </summary>
    public partial class ManagerOrderWindow : Window
    {

        IOrderRepository orderRepository;
        public ManagerOrderWindow(IOrderRepository repository)
        {
            InitializeComponent();
            orderRepository = repository;
        }

        

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            IProductRepository productRepository = new ProductRepository();
            var windowProducts = new ManagerProductWindow(productRepository);
            windowProducts.Show();
            this.Close();
            windowProducts.LoadProductList();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

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

        private Order GetOrderObjects()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = 1,
                    OrderDate = (DateTime)myOrderDate.SelectedDate,
                    RequiredDate = (DateTime)myRequiredDate.SelectedDate,
                    ShippedDate = (DateTime)myShippedDate.SelectedDate,
                    Freight = decimal.Parse(txtFreight.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }

            return order;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //if (!blankInput())
                //{
                //    MessageBox.Show("Blank input", "Update Product");
                //    return;
                //}
                
                try
                {
                    Order order = GetOrderObjects();
                    Order orders = orderRepository.GetOrderByID(order.OrderId);
                    order.MemberId = orders.MemberId;
                    orderRepository.UpdateOrder(order);
                    this.LoadOrderList();
                    MessageBox.Show($"Order {order.OrderId} updated successfully ", "Update Product");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update car");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (!blankInput())
                //{
                //    MessageBox.Show("Blank input", "Insert Product");
                //    return;
                //}
                Order order = GetOrderObjects();
                var myContextDB = new PRN221_As01Context();
                List<OrderDetail> orderDetails = myContextDB.OrderDetails.Where(item => item.OrderId == order.OrderId).ToList();
                foreach (OrderDetail item in orderDetails)
                {
                    myContextDB.OrderDetails.Remove(item);
                    myContextDB.SaveChanges();
                }

                orderRepository.DeleteOrder(order);
                this.LoadOrderList();
                MessageBox.Show($"Order {order.OrderId} deleted successfully ", "Delete Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }
        }
        internal void LoadOrderList()
        {
            var myContextDB = new PRN221_As01Context();
            lvOrders.ItemsSource = myContextDB.Orders.ToList();

        }
    }
}
