using Microsoft.AspNetCore.SignalR;

namespace PRN221_DinhChinh_Ass3.WebApp.Hubs
{
    public class BookHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userRole = httpContext?.Session.GetString("UserRole");

            if (userRole == "Admin")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
            }

            await base.OnConnectedAsync();
        }
        public async Task NotifyNewBook(string bookName)
        {
            await Clients.All.SendAsync("ReceiveNewBookNotification", bookName);
        }

        public async Task NotifyNewOrder(string name)
        {
            await Clients.All.SendAsync("ReceiveNewOrderNotification", name);
        }
    }
}
