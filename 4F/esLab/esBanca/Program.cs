//Alessio Modonesi 4F
//Scrivere un programma in C# mediante la OOP per gestire un
//c/c che permetta il versamento e il prelevamento di importi non superiori ai
//3.000€. IL programma deve partire da un saldo scelto a piacere.
using System;

namespace esBanca
{
    class Program
    {
        static void Main(string[] args)
        {
            Banca b = new Banca();
            CC c = new CC();
            double money;

            Console.WriteLine("Benvenuto, scegli un'opzione:");
            Console.WriteLine("-1 per versare sul tuo c/c");
            Console.WriteLine("-2 per prelevare dal tuo c/c");
            Console.WriteLine("-3 per mostrare il saldo del tuo c/c");
            Console.Write("Inserisci la tua scelta: ");
            int scelta = int.Parse(Console.ReadLine());

            if (scelta == 1)
            {
                Console.Write("Inserisci l'importo da versare sul tuo c/c: ");
                money = Convert.ToDouble(Console.ReadLine());

                if (c.Max3k(ref money) == true)
                {
                    b.Versa(ref money);
                    Console.WriteLine("Importo versato: {0}", money);
                    b.StampaSaldo(); 
                }
                else
                    Console.WriteLine("Ops, importo troppo alto");
            }        
            else if (scelta == 2)
            {
                Console.Write("Inserisci l'importo da prelevare sul tuo c/c: ");
                money = Convert.ToDouble(Console.ReadLine());

                if (c.Max3k(ref money) == true && c.Possibilità(ref money) == true)
                {
                    b.Preleva(ref money);
                    Console.WriteLine("Importo prelevato: {0}", money);
                    b.StampaSaldo(); 
                }
                else
                    Console.WriteLine("Ops, l'importo è troppo alto o sei povero come la merda");
            }    
            else if (scelta == 3)
                b.StampaSaldo();    
            else
                Console.WriteLine("Ops, valore non trovato");      
        }
    }

    class Banca
    {
        protected double saldo { get; set; }
        public Banca()
        {
            this.saldo = 5000; 
        }
        public void Versa(ref double money)
        {
            saldo += money;
        }
        public void Preleva(ref double money)
        {
            saldo -= money;
        }
        public void StampaSaldo()
        {
            Console.WriteLine("Il tuo saldo è: {0}", saldo);
        }
    }

    class CC:Banca
    {
        public bool Max3k(ref double money)
        {
            if (money <= 3000)
                return true;
            else
                return false;
        }

        public bool Possibilità(ref double money)
        {
            if (money <= saldo)
                return true;
            else
                return false;
        }

        public bool SetScelta(ref int scelta)
        {
            return true;
        }
    }
}
