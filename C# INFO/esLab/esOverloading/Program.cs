using System;

namespace OverLoading
{
    class Program
    {
        class Somma1
        {
            public int a, b;
            public Somma1()
            {
                this.a = 0;
                this.b = 0;
            }
            public void Somma(int a, int b)
            { Console.WriteLine(a + b); }
            public void Somma(float x, float y)
            { Console.WriteLine(x + y); }
        }

        class Somma2 : Somma1
        {
            string str1, str2;
            public Somma2()
            {
                this.str1 = "";
                this.str2 = "";
            }
            public void Somma(string str1, string str2)
            { Console.WriteLine(str1 + str2); }
        }
        
        static void Main(string[] args)
        {
            Somma2 a = new Somma2();
            a.Somma(10, 20);
            a.Somma(10.5f, 20.5f);
            a.Somma("Ciao", " a tutti");
        }
    }
}
