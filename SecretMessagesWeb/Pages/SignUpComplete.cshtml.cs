using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretMessages_Library.Routines;

namespace SecretMessagesWeb.Pages
{
    [BindProperties]
    public class SignUpCompleteModel : PageModel
    {
        private readonly ILoginRoutine _loginRoutine;

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public bool WasSignupSuccessful { get; set; }

        public SignUpCompleteModel(ILoginRoutine loginRoutine)
        {
            _loginRoutine = loginRoutine;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            WasSignupSuccessful = _loginRoutine.SignUp(UserName, Password);

            return Page();
        }
    }
}
