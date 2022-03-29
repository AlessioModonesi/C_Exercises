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
        public static string[] readerName = new string[row];
        public static string[] readerEmail = new string[row];
        public static string[] readerPass = new string[row];
        public static string[] readerData = new string[row];
        public static string utente, email, passwd, error;
        public static bool exist = false;

        public static void Main(string[] args)
        {
            ReadFile();
            CreateHostBuilder(args).Build().Run();
        }

        public static void ReadFile()
        {
            readerName = null; readerEmail = null; readerPass = null;
            readerName = File.ReadAllLines(MainPath + $"\\File\\Login\\name.txt");
            readerEmail = File.ReadAllLines(MainPath + $"\\File\\Login\\email.txt");
            readerPass = File.ReadAllLines(MainPath + $"\\File\\Login\\passwd.txt");
            readerData = File.ReadAllLines(MainPath + $"\\File\\Data\\admin.txt");
        }

        public static void WriteFile()
        {
            if (utente != null && email != null && passwd != null)
            {
                string str1 = $"\n{utente}";
                File.AppendAllText(MainPath + "\\File\\Login\\name.txt", str1);
                string str2 = $"\n{email}";
                File.AppendAllText(MainPath + "\\File\\Login\\email.txt", str2);
                string str3 = $"\n{passwd}";
                File.AppendAllText(MainPath + "\\File\\Login\\passwd.txt", str3);
                utente = null; email = null; passwd = null;
            }
        }

        public static void CreaFile()
        {
            //readerData = File.ReadAllLines(MainPath + $"\\File\\Data\\{utente}.txt");
        }

        public static int Search(ref string email, ref string passwd)
        {
            for (int i = 0; i < readerEmail.Length; i++)
            {
                if (email == readerEmail[i] && passwd == readerPass[i]) //se mail e password compaiono nei file
                {
                    exist = true;
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
