using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebPoject.Pages.MainLeftPanelContent
{
    public class StandartLeftPanelPageModel : PageModel
    {
        public string UrlString { get; set; }
        public IActionResult OnGet(string tema, string id)
        {
            UrlString = $"ContentHtml/{id}";

            return Page();
        }
    }
}
