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
    /// Interaction logic for ManagerOrderCustomerWindow.xaml
    /// </summary>
    public partial class ManagerOrderCustomerWindow : Window
    {
        IOrderRepository orderRepository;
        Member member;
        public ManagerOrderCustomerWindow(IOrderRepository repository, Member members)
        {
            InitializeComponent();
            orderRepository = repository;
            member = members;
            var PRN221_As01Context = new PRN221_As01Context();
            List<Product> products = PRN221_As01Context.Products.ToList();
            ComboBox1.Items.Clear();
            foreach (Product product in products)
            {
                ComboBox1.Items.Add(product.ProductName);
            }
        }

        

        public ManagerOrderCustomerWindow()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pName = ComboBox1.SelectedItem.ToString();
            Product product = null;
            try
            {
                var myContextDB = new PRN221_As01Context();
                product = myContextDB.Products.SingleOrDefault(item => item.ProductName.Equals(pName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            txtUnitPrice.Text = product.UnitPrice.ToString();



        }

        private Order GetOrderObjects()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = member.MemberId,
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

        private OrderDetail GetOrderDetailObjects(Product product)
        {
            OrderDetail orderDetail= null;
            try
            {
                orderDetail = new OrderDetail
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    ProductId = product.ProductId,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = 0,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }

            return orderDetail;
        }

        //private bool blankInput()
        //{
        //    if (txtOrderId.Text.Length < 1 || myOrderDate.SelectedDate.Len < 1 || txtProductName.Text.Length < 1
        //        || txtUnitPrice.Text.Length < 1 || txtUnitsInStock.Text.Length < 1 || txtWeight.Text.Length < 1) return false;
        //    return true;
        //}

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (!blankInput())
                //{
                //    MessageBox.Show("Blank input", "Insert Product");
                //    return;
                //}
                Order order = orderRepository.GetOrderByID(int.Parse(txtOrderId.Text));
                if (order!=null)
                {
                    IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
                    string pName = ComboBox1.SelectedItem.ToString();
                    var myContextDB = new PRN221_As01Context();
                    Product product = myContextDB.Products.SingleOrDefault(item => item.ProductName.Equals(pName));

                    OrderDetail orderDetail = GetOrderDetailObjects(product);
                    OrderDetail orderDetailCheckExist = myContextDB.OrderDetails.SingleOrDefault(item => item.ProductId == product.ProductId && item.OrderId == int.Parse(txtOrderId.Text));
                    
                    if (orderDetailCheckExist != null)
                    {
                        orderDetailCheckExist.Quantity += int.Parse(txtQuantity.Text);
                        orderDetailRepository.UpdateOrderDetail(orderDetailCheckExist);
                    }
                    else
                    {
                        orderDetailRepository.InsertOrderDetail(orderDetail);
                    }
                    
                    this.LoadOrderList();
                    MessageBox.Show($"Order {order.OrderId} order successfully ", "Order");
                }
                else
                {
                    Order orders = GetOrderObjects();
                    orderRepository.InsertOrder(orders);
                    
                    IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
                    string pName = ComboBox1.SelectedItem.ToString();
                    var myContextDB = new PRN221_As01Context();
                    Product product = myContextDB.Products.SingleOrDefault(item => item.ProductName.Equals(pName));
                    
                    OrderDetail orderDetail = GetOrderDetailObjects(product);
                    orderDetailRepository.InsertOrderDetail(orderDetail);
                    this.LoadOrderList();
                    MessageBox.Show($"Order {orders.OrderId} order successfully ", "Order");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
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

        

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool check = true;
                MemberRepository memberRepository = new MemberRepository();
                UpdateMemberWindow updateMemberWindow = new UpdateMemberWindow(memberRepository, member,check);
                this.Close();
                updateMemberWindow.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Member");
            }
        }


        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        internal void LoadOrderList()
        {
            var myContextDB = new PRN221_As01Context();
            lvOrders.ItemsSource = myContextDB.Orders.Where(p => p.MemberId == member.MemberId).ToList();

        }
    }
}
