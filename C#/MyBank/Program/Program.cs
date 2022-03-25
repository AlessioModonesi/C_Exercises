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
        public static string[] reader = new string[1000];
        public static string utente;
        public static string email;
        public static string passwd;

        public static void Main(string[] args)
        {
            reader = File.ReadAllLines(MainPath + $"\\login\\admin.txt");
            CreateHostBuilder(args).Build().Run();
        }

        public static void Split()
        {
            string[] nome = reader[0].Split($",{email},{passwd}");
            string[] mail = reader[0].Split($"{utente},,{passwd}");
            string[] pass = reader[0].Split($"{utente},{email},");
            File.AppendAllText(MainPath + "\\login\\admin.txt", "\n");
            File.AppendAllText(MainPath + "\\login\\admin.txt", nome[0]);
            File.AppendAllText(MainPath + "\\login\\admin.txt", ",");
            File.AppendAllText(MainPath + "\\login\\admin.txt", mail[0]);
            File.AppendAllText(MainPath + "\\login\\admin.txt", ",");
            File.AppendAllText(MainPath + "\\login\\admin.txt", pass[0]);
        }

        public static object ReadFile()
        {
            //reader = File.ReadAllLines(MainPath + $"\\login\\admin.txt");
            return 0;
        }

        public static object WriteFile()
        {
            if (utente != null && email != null && passwd != null)
            {
                string credential = $"\n{utente},{email},{passwd}";
                File.AppendAllText(MainPath + "\\login\\admin.txt", credential);
                utente = null; email = null; passwd = null;
            }
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
