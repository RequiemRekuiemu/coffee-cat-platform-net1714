using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Repositories;
using Repositories.Impl;

namespace CoffeeCatPlatform.Pages
{
    public class LoginStaffModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public int ID { get; set; }

        private readonly IRepositoryBase<Customer> _customerRepo;
        private readonly IRepositoryBase<Staff> _staffRepo;

        private const string SessionKeyName = "_Name";
        private const string SessionKeyId = "_Id";
        private const string SessionKeyType = "_Type";

        public LoginStaffModel()
        {
            _customerRepo = new CustomerRepository();
            _staffRepo = new StaffRepository();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string type = "Staff";
            var staff = _staffRepo.GetAll().FirstOrDefault(c =>
                c.Email.Equals(Email) &&
                c.Password.Equals(Password));
            if (staff == null)
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
                return RedirectToPage("/Login");
            }
            else
            {
                if (SessionCheck() == false)
                {
                    HttpContext.Session.SetString(SessionKeyName, staff.Name);
                    HttpContext.Session.SetInt32(SessionKeyId, staff.StaffId);
                    HttpContext.Session.SetString(SessionKeyType, type);
                }
                return RedirectToPage("/MenuPages/Menu", new { id = ID });
            }
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
    }
}
