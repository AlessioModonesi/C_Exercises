using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBank.Pages
{
    public class LoginModel : PageModel
    {
        public string email { get; set; }
        public string passwd { get; set; }
        public string status { get; set; }

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
            if (status != "ON")
            {
                if (email == "admin@gmail.com" && passwd == "admin")
                    return status = "ON";
                else
                    return status = "OFF";
            }
            else
                return 0;
        }
    }
}
