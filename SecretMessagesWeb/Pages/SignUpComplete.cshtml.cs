using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecretMessagesWeb.Pages
{
    public class SignUpCompleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
