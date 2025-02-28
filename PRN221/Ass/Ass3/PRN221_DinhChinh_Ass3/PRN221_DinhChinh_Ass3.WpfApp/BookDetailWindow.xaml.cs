using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.DataAccess;
using PRN221_DinhChinh_Ass3.Model;
using Microsoft.AspNetCore.SignalR.Client;
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

namespace PRN221_DinhChinh_Ass3.WpfApp
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        private Book book;
        private ShipRepository shipRepository;
        private HubConnection _hubConnection;
        public BookDetailWindow(Book selectedBook)
        {
            InitializeComponent();
            shipRepository = new ShipRepository(new DataAccess.Repository.AppDbContext());
            book = selectedBook;
            DataContext = book;
          
        }
        private async void ConnectToSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7027/bookHub")
                .Build();

            await _hubConnection.StartAsync();
        }
        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            var ship = new Ship();
            ship.BookId = book.BookId;
            ship.DateOrder = DateTime.Now;
            ship.UserOrderId = Session.UserId;
            //ship.UserOrderId = 
            shipRepository.Add(ship);

            await _hubConnection.InvokeAsync("NotifyNewOrder", Session.UserName);

            await shipRepository.SaveChangeAsync();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
