using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using System.Windows;

namespace SalesWPFApp
{
    public partial class MainWindow : Window
    {
        private bool IsAdmin; // This would be set based on the logged-in user
        private ProductDAO productDAO = new ProductDAO(new ProductRepository());
        private OrderDAO OrderDAO = new OrderDAO(new OrderRepository());
        private OrderDetailDAO OrderDetailDAO = new OrderDetailDAO(new OrderDetailRepository());


        public MainWindow(bool isAdmin)
        {
            InitializeComponent();
            IsAdmin = isAdmin;
            SetVisibility();
        }

        private void SetVisibility()
        {
            if (IsAdmin)
            {
                AdminPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                UserPanel.Visibility = Visibility.Visible;
                LoadProducts(); // Load products when user panel is visible
            }
        }

        private void LoadProducts()
        {
            ProductDataGrid.ItemsSource = productDAO.GetAllProducts();
        }

        private void ManageMembers_Click(object sender, RoutedEventArgs e)
        {
            // Open the member management window
            WindowMembers windowMembers = new WindowMembers();
            windowMembers.Show();
        }

        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            // Open the product management window
            WindowProducts windowProducts = new WindowProducts();
            windowProducts.Show();
        }

        private void ManageOrders_Click(object sender, RoutedEventArgs e)
        {
            // Open the order management window
            WindowOrders windowOrders = new WindowOrders();
            windowOrders.Show();
        }

        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            // Open product list window for user
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = ProductDataGrid.SelectedItems.Cast<Product>().ToList();
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Please select at least one product to place an order.");
                return;
            }

            // Create a new order
            var order = new Order
            {
                MemberId = (int) MySession.LoggedInMemberId,
                OrderDate = System.DateTime.Now,
                RequiredDate = System.DateTime.Now.AddDays(7), // Set an arbitrary required date
                Freight = 5.00M // Set some arbitrary freight cost
            };
            OrderDAO.AddOrder(order); // Save the order

            // Add order details for each selected product
            foreach (var product in selectedProducts)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = product.ProductId,
                    UnitPrice = product.UnitPrice,
                    Quantity = 1, // Default to 1 (could allow user to input quantity)
                    Discount = 0 // Assume no discount for now
                };

                OrderDetailDAO.AddOrderDetail(orderDetail); // Save order detail
            }

            MessageBox.Show("Order placed successfully!");
        }

        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the logged-in member's ID is available
            if (!MySession.LoggedInMemberId.HasValue)
            {
                MessageBox.Show("Error: No member is logged in.");
                return;
            }

            // Fetch the orders for the logged-in member
            var orders = OrderDAO.GetAllOrders()
                         .Where(order => order.MemberId == MySession.LoggedInMemberId.Value)
                         .ToList();

            // Check if there are any orders
            if (orders.Count == 0)
            {
                MessageBox.Show("You have no orders.");
                return;
            }

            // Bind the orders to the DataGrid
            OrdersDataGrid.ItemsSource = orders;
            OrdersDataGrid.Visibility = Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin login = new WindowLogin();
            login.Show();
            MySession.LoggedInMemberId = null;
            this.Close();
        }
    }
}
