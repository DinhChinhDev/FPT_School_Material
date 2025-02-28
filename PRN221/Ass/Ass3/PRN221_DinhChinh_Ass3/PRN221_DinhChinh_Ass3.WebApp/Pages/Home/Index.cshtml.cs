using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_DinhChinh_Ass3.Model;
using PRN221_DinhChinh_Ass3.DataAccess.Repository;
using PRN221_DinhChinh_Ass3.DataAccess.Repository.IRepositories;
using Microsoft.AspNetCore.SignalR;
using PRN221_DinhChinh_Ass3.WebApp.Hubs;
using Microsoft.AspNetCore.Http;
using PRN221_DinhChinh_Ass3.WebApp.Filter;

namespace PRN221_DinhChinh_Ass3.WebApp.Pages.Home
{
    [SessionAuthorize]
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Ship> _orderRepository;
        private readonly IGenericRepository<AppUser> _userRepository;
        private readonly IHubContext<BookHub> _hubContext;

        public IndexModel(
            IGenericRepository<Book> repository,
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<AppUser> userRepository,
            IGenericRepository<Ship> orderRepository,
            IHubContext<BookHub> hubContext)
        {
            _hubContext = hubContext;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public IEnumerable<Book> Books { get; set; } = default!;
        public IEnumerable<Category> Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? searchString = null, int? categoryId = null)
        {
            Categories = await _categoryRepository.GetAllAsync();

            var query = await _repository.GetAllAsync(includeProperties: "Category");

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x =>
                    x.BookName.ToLower().Contains(searchString.ToLower()) ||
                    x.Category.CategoryName.ToLower().Contains(searchString.ToLower()));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            Books = query.OrderBy(x => x.BookName);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Partial("_BookListPartial", Books);
            }

            return Page();
        }


        public async Task<IActionResult> OnPostPlaceOrderAsync(int bookId)
        {
            var BookId = bookId;
            var OrderDate = DateTime.Now;
            var UserOrderId = HttpContext.Session.GetInt32("UserId");

            var shippers = await _userRepository.GetAllAsync(x => x.IsShipper);
            if (shippers == null || !shippers.Any())
            {
                return new JsonResult(new { success = false, message = "No available shippers." });
            }

            var random = new Random();
            var randomShipper = shippers.ElementAt(random.Next(shippers.Count()));

            var ship = new Ship
            {
                BookId = BookId,
                DateOrder = OrderDate,
                UserOrderId = UserOrderId,
                UserShipId = randomShipper.AppUserId,
            };

            _orderRepository.Add(ship);
            await _orderRepository.SaveChangeAsync();

            await _hubContext.Clients.Groups("Admin").SendAsync("ReceiveNewOrderNotification", HttpContext.Session.GetString("Name"));
            return new JsonResult(new { success = true, message = "Order placed successfully!" });
        }


    }
}
