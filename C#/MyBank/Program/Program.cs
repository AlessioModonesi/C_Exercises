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
        public static int row = 1, pnt = 0;
        //public static string[,] login = new string[row, 3];
        public static string[] readerName = new string[row];
        public static string[] readerEmail = new string[row];
        public static string[] readerPass = new string[row];
        public static string utente, email, passwd, error;

        public static void Main(string[] args)
        {
            ReadFile();
            CreateHostBuilder(args).Build().Run();
        }

        public static void ReadFile()
        {
            readerName = null; readerEmail = null; readerPass = null;
            readerName = File.ReadAllLines(MainPath + $"\\login\\name.txt");
            readerEmail = File.ReadAllLines(MainPath + $"\\login\\email.txt");
            readerPass = File.ReadAllLines(MainPath + $"\\login\\passwd.txt");
        }

        public static void WriteFile()
        {
            if (utente != null && email != null && passwd != null)
            {
                string str1 = $"\n{utente}";
                File.AppendAllText(MainPath + "\\login\\name.txt", str1);
                string str2 = $"\n{email}";
                File.AppendAllText(MainPath + "\\login\\mail.txt", str2);
                string str3 = $"\n{passwd}";
                File.AppendAllText(MainPath + "\\login\\pass.txt", str3);
                utente = null; email = null; passwd = null;
            }
        }

        public static int Search(ref string email, ref string passwd)
        {
            for (int i = 0; i < row; i++)
            {
                if (email == readerEmail[i] && passwd == readerPass[i])
                {
                    return pnt = i;
                }
            }
            return -1;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
