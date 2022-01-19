//Alessio Modonesi 4F
//Dopo aver acquisito da tastiera una serie di prezzi relativi ai cellulari in vendita in un negozio,
//scrivere il codice di un programma(OOP) in C# che visualizzi i prezzi maggiori di 100€.
using System;

namespace es_6_smartphone
{
    class Smartphone
    {
        //attributi
        double[] prezzi = new double[0]; //dichiaro l'array che conterrà tutti i prezzi degli smartphone
        double[] maggiori = new double[0]; //dichiaro l'array che conterrà solo i prezzi maggiori di 100€

        //costruttore
        public Smartphone(double[] prezzi)
        {
            this.prezzi = prezzi; //inizializzo l'array prezzi
        }

        //metodi 
        public bool SetPrezzi(int pos, double prezzoTel) //questo metodo mi consente di salvare i prezzi, controllando che il valore inserito sia valido
        {
            try
            {
                Array.Resize(ref prezzi, prezzi.Length + 1); //resizo l'array
                prezzi[pos] = prezzoTel; //il prezzo del telefono è salvato nell'array prezzi[pos]

                if (prezzi[pos] > 0) return true; //se il valore è valido, ritorno il valore
                else return false; //ritorno il valore
            }

            catch
            {
                return false; //ritorno il valore
            }
        }

        public void PrezziMaggiori() //questo metodo mi consente di salvare i prezzi maggiori di 100 su un altro array
        {
            int posMagg = 0; //inizializzo l'indice dell'array contenente i prezzi maggiori di 100
            for (int pos = 0; pos < prezzi.Length; pos++) //questo ciclo esamina tutto l'array prezzi
            {
                if (prezzi[pos] > 100) //se il prezzo in posizione [pos] è maggiore di 100
                {
                    Array.Resize(ref maggiori, maggiori.Length + 1); //resizo l'array
                    maggiori[posMagg] = prezzi[pos]; //salvo il prezzo nell'array adeguato
                    posMagg++; //incremento l'indice
                }
            }
        }

        static void Main(string[] args)
        {
            int posSmartphone = 0; //inizializzo la variabile
            double[] prezzi = new double[0]; //dichiaro l'array
            Smartphone sm = new Smartphone(prezzi); //creo un'istanza della classe Smartphone

            Console.WriteLine("Quanti prezzi vuoi inserire?");
            int n = int.Parse(Console.ReadLine()); //input di n prezzi

            for (int x = 0; x < n; x++) //questo ciclo  mi consente di inserire n valori nell'array
            {
                posSmartphone++; //incremento la variabile
                Console.WriteLine("Inserisci il prezzo del {0}° smartphone", posSmartphone);
                //questo è il ciclo del try-catch, che mi permette di riiserire il valore qualora fosse sbagliato
                while (sm.SetPrezzi(x, int.Parse(Console.ReadLine())) == false) 
                {
                    Console.WriteLine("ERROR: valore non valido"); //messaggio di errore
                    Console.WriteLine("Reinserisci il prezzo del smartphone");
                }
            }

            sm.PrezziMaggiori(); //richiamo il metodo che passerà l'array di prezzi maggiori di 100
            n = sm.maggiori.Length; //assegno alla variabile il valore della lunghezza dell'array 

            if (n > 0) //se n > 0, quindi se l'array "maggiori" ha almeno un valore da stampare
            {
                Console.WriteLine("Questi sono i prezzi maggiori di 100");
                for (int i = 0; i < n; i++) Console.WriteLine(sm.maggiori[i]); //stampo il valore in posizione [i]
            }

            else Console.WriteLine("Non ci sono prezzi maggiori di 100"); //se non ci sono valori mostro a video un messaggio
        }
    }
}
