using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebPoject.Pages.Employees
{
    [Authorize]
    public class EmployeesModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
