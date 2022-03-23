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
        public static string[] array = new string[1000];
        public static string utente;
        public static string email;
        public static string passwd;

        public static void Main(string[] args)
        {
            array = File.ReadAllLines(MainPath + $"\\login\\admin.txt");
            CreateHostBuilder(args).Build().Run();
        }

        public static object SignUp() //problemi con l'accesso ai file
        {
            //using (StreamWriter creaFile = File.CreateText($"{MainPath}\\login\\{utente}.txt")) { }
            //File.AppendAllText(MainPath + $"\\login\\{utente}.txt", utente);
            //File.AppendAllText(MainPath + $"\\login\\{utente}.txt", email);
            //File.AppendAllText(MainPath + $"\\login\\{utente}.txt", passwd);
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
