using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MyBank
{
    public class Program
    {
        public static string MainPath = Environment.CurrentDirectory;
        public static string[] login = new string[1000];
        public static string email;
        public static string passwd;

        public static void Main(string[] args)
        {
            login = File.ReadAllLines(MainPath + $"\\Login.txt");
            CreateHostBuilder(args).Build().Run();
        }

        public static object SignUp()
        {
            //File.AppendAllText(MainPath + $"\\Login.txt", email);
            //File.AppendAllText(MainPath + $"\\Login.txt", passwd);
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
