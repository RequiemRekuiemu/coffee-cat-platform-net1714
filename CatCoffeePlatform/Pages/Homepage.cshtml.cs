using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeCatPlatform.Pages
{
    public class HomepageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
