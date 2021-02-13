using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILoginRoutine _loginRoutine;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public int UserId { get; set; }


        public LoginModel(ILoginRoutine loginRoutine)
        {
            _loginRoutine = loginRoutine;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            (bool, int) loginResult = _loginRoutine.SignIn(UserName, Password);

            if (loginResult.Item1 == true)
            {
                UserId = loginResult.Item2;

                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
