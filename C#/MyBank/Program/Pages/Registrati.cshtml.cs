using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class RegistratiModel : PageModel
    {
        public void OnGet()
        {
            
        }
        public void OnPostSignUp(string email, string passwd)
        {
            Program.email = email;
            Program.passwd = passwd;
        }
    }
}
