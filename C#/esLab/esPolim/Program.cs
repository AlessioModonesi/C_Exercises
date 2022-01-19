/*Si crei la classe dipendente con i soli attributi: matricola, nome e cognome.
La classe avrà un metodo che calcola la retribuzione oraria. 
Dalla nostra classe dipendente vogliamo derivare tre differenti classi: dirigente, impiegato e operaio. 
Visualizzare la retribuzione oraria dei tre dipendenti sapendo che:
la retribuzione oraria per l’operario è 35€/h, 
la retribuzione oraria per l’impiegato aumenta del 30%, 
la retribuzione oraria per il dirigente aumenta del 50%.*/
using System;

namespace esPolim
{
    class Program
    {
        class Dipendente
        {
            protected float matricola;
            protected string nome;
            protected string cognome;

            public Dipendente(float matricola, string nome ,string cognome)
            {
                this.matricola = matricola;
                this.nome = nome;
                this.cognome = cognome;
            }

            public virtual double Retribuzione(ref double soldi)
            {
                return soldi;
            }
        }

        class Dirigente : Dipendente
        {
            public Dirigente(float matricola, string nome ,string cognome) : base(matricola, nome, cognome){ }
            public override double Retribuzione(ref double soldi)
            {
                soldi += soldi*0.50;
                return soldi;
            }
        }

        class Impiegato : Dipendente
        {
            public Impiegato(float matricola, string nome ,string cognome) : base(matricola, nome, cognome){ }
            public override double Retribuzione(ref double soldi)
            {
                soldi += soldi*0.30;
                return soldi;
            }
        }

        class Operaio : Dipendente
        {
            public Operaio(float matricola, string nome ,string cognome) : base(matricola, nome, cognome){ }
            public override double Retribuzione(double soldi)
            {
                soldi = 35;
                return soldi;
            }
        }

        static void Main(string[] args)
        {
            Dirigente dir = new Dirigente(123, "Mario", "Rossi");
            Impiegato imp = new Impiegato(456, "Alessio", "Bianchi");
            Operaio ope = new Operaio(789, "Simone", "Verdi");

            double soldi = 0.0;
            double retribuzione3 = ope.Retribuzione(soldi);
            double retribuzione1 = dir.Retribuzione(ref soldi);
            double retribuzione2 = imp.Retribuzione(ref soldi);

            Console.WriteLine("Dirigente: {0}/h", retribuzione1);
            Console.WriteLine("Impiegato: {0}/h", retribuzione2);
            Console.WriteLine("Operaio: {0}/h", retribuzione3);
        }
    }
}
