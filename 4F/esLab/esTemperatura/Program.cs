//Alessio Modonesi 4F
//Dopo aver acquisito da tastiera una serie di dati relativi alla misurazione della temperatura di una
//certa città, scrivere il codice di un programma(OOP) in C# che determini e visualizzi la temperatura
//più bassa e quella più alta.
using System;

namespace es_5_temperatura
{
    class Temp
    {
        //attributi 
        int t,min,max; //dichiaro le variabili

        //costruttore
        public Temp(int t)
        {
            //inizializzo le variabili
            this.t = t; 
            min = 9999;
            max = -9999;
        }

        //metodi
        public bool SetTemp() //questo metodo mi consente di settare il valore della varie temperature, controllando che il valore inserito sia valido
        {
            try
            {
                t = int.Parse(Console.ReadLine()); //input di t
                return true; //ritorno il valore
            }

            catch   
            {
                return false; //ritorno il valore
            }
        }

        public int Min() //questo metodo calcola la temperatura minore
        {
            if (min > t) min = t; //se min > t, assegno a t il valore di min
            return min; //ritorno il valore
        }

        public int Max() //questo metodo calcola la temperatura minore
        {
            if (max < t) max = t; //se max < t, assegno a t il valore di max
            return max; //ritorno il valore
        }

        static void Main(string[] args)
        {
            int n,c=0,t=0; //inizializzo le variabili
            Temp k = new Temp(t); //creo un'istanza della classe Temp

            Console.WriteLine("Quante temperature vuoi inserire?");
            n = int.Parse(Console.ReadLine()); //input del numero di temperature

            for (int i=0; i<n; i++) //creo un ciclo for che mi permette di inserire n temperature
            {
                c++; //aumento il contatore del numero di temperature
                Console.Write("Inserisci la {0}a temperatura: ",c);
                while (k.SetTemp() == false) //questo è il ciclo del try-catch, che mi permette di riiserire il valore qualora fosse sbagliato
                {
                    Console.WriteLine("ERROR: valore non valido"); //messaggio di errore
                    Console.Write("Inserisci nuovamente la {0}a temperatura: ", c);
                }

                k.Min(); //passo il valore minimo della temperatura
                k.Max(); //passo il valore massimo della temperature
            }

            //mostro a video i risultati
            Console.WriteLine("La temperatura minima è: " + k.Min());
            Console.WriteLine("La temperatura massima è: " + k.Max());
        }
    }
}
