using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostLogin(string email, string passwd)
        {
            if (email == Program.login[0] && passwd == Program.login[1])
                Startup.adminSetup = true;
            else
                Startup.adminSetup = false;
        }

        public void OnPostExit(string str)
        {
            Startup.adminSetup = false;
        }
    }
}
