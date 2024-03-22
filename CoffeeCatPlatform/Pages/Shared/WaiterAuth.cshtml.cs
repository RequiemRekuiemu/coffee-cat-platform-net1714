using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeCatPlatform.Pages.Shared
{
    public class WaiterAuthModel : PageModel
    {
        private const string SessionKeyName = "_Name";
        private const string SessionKeyId = "_Id";
        private const string SessionKeyType = "_Type";

        public IActionResult WaiterAuthorize()
        {
            if (SessionCheck() == false)
            {
                return RedirectToPage("/ErrorPages/NotLoggedInError");
            }
            else if (StaffCheck() == false)
            {
                return RedirectToPage("/ErrorPages/NotAuthorizedError");
            }
            return null;
        }

        private bool SessionCheck()
        {
            bool result = true;
            if (String.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName))
                && String.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyId))
                && String.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyType)))
            {
                result = false;
            }
            return result;
        }

        private bool StaffCheck()
        {
            bool result = false;
            if (HttpContext.Session.GetString(SessionKeyType) == "Staff")
            {
                result = true;
            }
            return result;
        }
    }
}
