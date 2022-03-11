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
        public string email;
        public string passwd;

        public void OnGet()
        {
        }

        public void OnPost(string email, string passwd)
        {
            this.email = email;
            this.passwd = passwd;
        }

        public void OnPostLogin(string email, string passwd)
        {
            if (email == "admin" && passwd == "admin")
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
