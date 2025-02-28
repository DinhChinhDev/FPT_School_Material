using System.Windows;
using DataAccess.Repository;
using BusinessObject;
using System.Collections.Generic;

namespace SalesWPFApp
{
    public partial class WindowOrders : Window
    {
        private OrderRepository orderRepository = new OrderRepository();
        private OrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        public WindowOrders()
        {
            InitializeComponent();
            LoadOrders();
        }

        // Load orders from the database and display them in the DataGrid
        private void LoadOrders()
        {
            List<Order> orders = new List<Order>(orderRepository.GetAll());
            dgOrders.ItemsSource = orders;
        }

        // Load order details when an order is selected
        private void DgOrders_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgOrders.SelectedItem is Order selectedOrder)
            {
                LoadOrderDetails(selectedOrder.OrderId);
            }
        }

        // Load the details for a specific order
        private void LoadOrderDetails(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>(orderDetailRepository.GetAll().Where(od => od.OrderId == orderId));
            dgOrderDetails.ItemsSource = orderDetails;
        }
    }
}
