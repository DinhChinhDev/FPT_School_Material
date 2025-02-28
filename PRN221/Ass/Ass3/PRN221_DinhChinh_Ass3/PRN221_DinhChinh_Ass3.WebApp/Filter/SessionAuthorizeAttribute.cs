using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PRN221_DinhChinh_Ass3.WebApp.Filter
{
    public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public SessionAuthorizeAttribute(string requiredRole = null)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = context.HttpContext.Session;

            // Check if the user is logged in
            var userId = session.GetInt32("UserId");
            var userRole = session.GetString("UserRole");

            if (userRole != "Admin" && userId == null)
            {
                // If not logged in, redirect to login page
                context.Result = new RedirectToPageResult("/Login/Login");
                return;
            }

            // If a specific role is required, check if it matches the user's role
            if (!string.IsNullOrEmpty(_requiredRole) && _requiredRole != userRole)
            {
                // If the user's role does not match, redirect to an unauthorized page or handle as needed
                context.Result = new RedirectToPageResult("/Login/Unauthorized");
            }
        }
    }
}
