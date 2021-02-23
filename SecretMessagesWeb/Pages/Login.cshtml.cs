using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly ILoginRoutine _loginRoutine;

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserId { get; set; }


        public LoginModel(ILoginRoutine loginRoutine)
        {
            _loginRoutine = loginRoutine;
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("UserName") == null)
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost()
        {
            (bool, int) loginResult = _loginRoutine.SignIn(UserName, Password);

            if (loginResult.Item1 == true)
            {
                HttpContext.Session.SetInt32("UserId", loginResult.Item2);
                HttpContext.Session.SetString("UserName", UserName);

                return RedirectToPage("UserDashboard");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
