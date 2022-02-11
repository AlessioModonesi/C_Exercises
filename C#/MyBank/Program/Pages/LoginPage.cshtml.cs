using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace programCc.Pages
{
    public class LoginPageModel : PageModel
    {
        public string email { get; set; }
        public string passwd { get; set; }
        public string logged { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string email, string passwd)
        {
            this.email = email;
            this.passwd = passwd;
        }

        public object Login()
        {
            if (email == "prova@gmail.com" && passwd == "1234")
                return logged = "Logged";
            else
                return logged = "Non logged";
        }
    }
}
