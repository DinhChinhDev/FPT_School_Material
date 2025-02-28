using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using PRN221_DinhChinh_Ass3.DataAccess.Repository.IRepositories;
using PRN221_DinhChinh_Ass3.Model;

namespace PRN221_DinhChinh_Ass3.WebApp.Pages.Login
{
        public class LoginModel : PageModel
        {
            private readonly IGenericRepository<AppUser> _userRepository;

            [BindProperty]
            public string UserName { get; set; }

            [BindProperty]
            public string Password { get; set; }

            public string ErrorMessage { get; set; } = string.Empty;

            public LoginModel(IGenericRepository<AppUser> userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (UserName == "ad" && Password == "123")
                {
                    HttpContext.Session.SetString("UserRole", "Admin");
                    return RedirectToPage("/Ships/Index");
                }
                else
                {

                    var user = await _userRepository.GetFirstOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
                    if (user == null)
                    {
                        ErrorMessage = "Invalid username or password.";
                        return Page();
                    }
                    else
                    {

                        // Set session variables for user
                        HttpContext.Session.SetInt32("UserId", user.AppUserId);
                        HttpContext.Session.SetString("Name", user.UserName);
                        HttpContext.Session.SetString("UserRole", user.IsShipper ? "Shipper" : "User");

                        // Redirect to homepage or admin area based on role
                        return user.IsShipper ? RedirectToPage("/Shipper/Home") : RedirectToPage("/Home/Index");
                    }
                }
            }
        }
    }
