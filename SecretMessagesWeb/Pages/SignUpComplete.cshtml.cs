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

        public string PasswordAgain { get; set; }

        public bool WasSignupSuccessful { get; set; }

        public string ErrorMessage { get; set; } = "";

        public SignUpCompleteModel(ILoginRoutine loginRoutine)
        {
            _loginRoutine = loginRoutine;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            bool isPasswordValid = _loginRoutine.ValidatePassword(Password, PasswordAgain);

            if (isPasswordValid)
            {
                WasSignupSuccessful = _loginRoutine.SignUp(UserName, Password);

                if (WasSignupSuccessful == false)
                {
                    ErrorMessage = "That username is unavailable.";
                }
            }
            else
            {
                WasSignupSuccessful = false;

                ErrorMessage = "Invalid password.";
            }

            return Page();
        }


    }
}
