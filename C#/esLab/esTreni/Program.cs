//Alessio Modonesi 4F 13/01/2022
//Scrivere il codice in C# per creare la classe Treni con i seguenti attributi: codtreno, tipo
//(regionale,nazionale,internazionale) ,nome e costo. La classe avrà 2 metodi che calcolano il costo del mezzo
//utilizzato e il costo per il suo utilizzo (calcolato dal percorso effettuato). Dalla classe si vogliono derivare 2
//differenti classi: Passeggeri e Merci che avranno 2 ulteriori attributi: numvagoni e alimentazione.
//Dopo aver visualizzato i dati (assegnati nel main o letti in input) calcolare e visualizzare:
//1) il costo dei 2 mezzi sapendo che il costo di un mezzo generico è 100.000€ mentre per il Passeggeri è
//aumentato del 25% e per il Merci aumenta del 35%;
//2) il costo per il suo utilizzo, dopo aver letto in input i km effettuati, sapendo che il prezzo al km per il
//treno Merci è di 100€ mentre per il Passeggeri è 150€;
//3) Il costo totale dei i due mezzi.
using System;

namespace verifica_13_01
{
    class Treni //classe padre
    {
        public string codTreno { get; set; } //codice del treno
        public string tipo { get; set; } //tipo di treno (regionale,nazionale,internazionale)
        public string nome { get; set; } //nome del treno
        public double costo { get; set; } //costo del treno
        
        //metodo di default: costruttore
        public Treni(string codTreno, string tipo, string nome, double costo)
        {
            this.codTreno = codTreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
        }
        
        //metodo per il calcolo del costo del mezzo (virtual)
        public virtual double costoMezzo()
        {
            return costo;
        }

        //metodo per il calcolo del costo dell'utilizzo (virtual)
        public virtual double costoUtilizzo(double km)
        {
            return costo;
        }
    }
    class Passeggieri : Treni //classe figlia
    {
        public int numVagoni {get; set;} //numero dei vagoni del treno passeggieri
        
        //metodo di default: costruttore
        public Passeggieri(string codTreno, string tipo, string nome, double costo, int numVagoni) : base(codTreno, tipo, nome, costo)
        {
            this.numVagoni = numVagoni;
        }

        //metodo per il calcolo del costo del mezzo (override)
        public override double costoMezzo()
        {
            costo *= 1.25; //calcolo il costo del treno
            return costo;
        }

        //metodo per il calcolo del costo dell'utilizzo (override)
        public override double costoUtilizzo(double km)
        { 
            costo += km * 150; //calcolo il costo dell'utilizzo
            return costo;
        }

        //metodo ToString per la visualizzazione dei dati (override)
        public override string ToString()
        {
            return $"\nTreno Passeggieri:\ncodTreno: {codTreno};\ntipo: {tipo};\nnome: {nome};\nnumVagoni: {numVagoni}";
        }
    }
    class Merci : Treni //classe figlia
    {
        public string alimentazione {get; set;} //tipo di alimentazione del treno merci

        //metodo di default: costruttore
        public Merci(string codTreno, string tipo, string nome, double costo, string alimentazione) : base(codTreno, tipo, nome, costo)
        {
            this.alimentazione = alimentazione;
        }

        //metodo per il calcolo del costo del mezzo (override)
        public override double costoMezzo()
        {
            costo *= 1.35; //calcolo il costo del treno
            return costo;
        }

        //metodo per il calcolo del costo dell'utilizzo (override)
        public override double costoUtilizzo(double km)
        {
            costo += km * 100; //calcolo il costo dell'utilizzo
            return costo;
        }

        //metodo ToString per la visualizzazione dei dati (override)
        public override string ToString()
        {
            return $"\nTreno Merci:\ncodTreno: {codTreno};\ntipo: {tipo};\nnome: {nome};\nalimentazione: {alimentazione}";
        }
    }
    class Program //classe Program
    {
        static void Main(string[] args)
        {
            //creo le due istanze delle classi Passeggieri e Merci
            Passeggieri Passeggieri = new Passeggieri("Pass123", "Internazionale", "FrecciaRossa", 100000, 10);
            Merci Merci = new Merci("Mer456", "Regionale", "Italo", 100000, "Diesel");
            Console.Clear();

            //input dei dati del treno passeggieri (sovrascrivendo quelli già esistenti). Utilizzo il metodo SET
            Console.Write("Inserisci il codice del Treno Passeggieri: ");
            Passeggieri.codTreno = Console.ReadLine();
            Console.Write("Inserisci il tipo di Treno Passeggieri: ");
            Passeggieri.tipo = Console.ReadLine();
            Console.Write("Inserisci il nome del Treno Passeggieri: ");
            Passeggieri.nome = Console.ReadLine();
            Console.Write("Inserisci il numero di vagoni del Treno Passeggieri: ");
            Passeggieri.numVagoni = int.Parse(Console.ReadLine());

            //input dei dati del treno Merci (sovrascrivendo quelli già esistenti). Utilizzo il metodo SET
            Console.Write("\nInserisci il codice del Treno Merci: ");
            Merci.codTreno = Console.ReadLine();
            Console.Write("Inserisci il tipo di Treno Merci: ");
            Merci.tipo = Console.ReadLine();
            Console.Write("Inserisci il nome del Treno Merci: ");
            Merci.nome = Console.ReadLine();
            Console.Write("Inserisci il tipo di alimentazione del Treno Merci: ");
            Merci.alimentazione = Console.ReadLine();
            
            //input dei km percorsi
            Console.Write("\nInserisci i km percorsi dai due Treni: ");
            double km = int.Parse(Console.ReadLine());

            //calcolo il costo dei due mezzi, partendo dal prezzo base di 100.000€
            Passeggieri.costoMezzo();
            Merci.costoMezzo();

            //mostro i dati dei due treni tramite il metodo ToString
            Console.WriteLine(Passeggieri.ToString());
            Console.WriteLine(Merci.ToString());

            //mostro in output il costo totale, sommandoci anche il costo/km
            Console.WriteLine($"\nIl Treno Passeggieri costa in totale: {Passeggieri.costoUtilizzo(km)} euro");
            Console.WriteLine($"Il Treno merci costa in totale: {Merci.costoUtilizzo(km)} euro");
            Console.WriteLine("\nPremi un tasto per uscire");
            Console.ReadKey();
        }
    }
}
