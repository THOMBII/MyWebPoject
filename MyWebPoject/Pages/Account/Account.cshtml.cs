using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace MyWebPoject.Pages.Account
{
    public class AccountModel : PageModel
    {
        public readonly SignInManager<IdentityUser> _signInManager;

        public string Msg {  get; set; }
        public AccountModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LogInUser Input { get; set; }

        public void OnGet()
        {
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return Page();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (returnUrl == null || Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect("/Employees/Employees");
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    Msg = "Неправильный логин и (или) пароль";
                }
            }
            return Page();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }

    }
}
