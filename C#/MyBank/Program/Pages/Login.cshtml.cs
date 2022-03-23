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
        public string error;

        public void OnGet()
        {
        }

        public void OnPostLogin(string email, string passwd)
        {
            if (email == Program.array[0] && passwd == Program.array[1])
                Startup.adminSetup = true;
            else if (email != Program.array[0])
            {
                Startup.adminSetup = false;
                error = "email";
            }   
            else
            {
                Startup.adminSetup = false;
                error = "passwd";
            }
        }

        public void OnPostExit()
        {
            Startup.adminSetup = false;
        }
    }
}
