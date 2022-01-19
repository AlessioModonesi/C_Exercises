//Alessio Modonesi 4F
using System;

namespace ClassDeriv
{
    class ClassDeriv
    {
        class Persona // Classe base
        {
            public int Badge { get; set; }
            public string Cognome { get; set; }
            public string Nome { get; set; }
            public void StampaInformazioni()
            {
                Console.WriteLine("Badge n. {0}, {1}, {2}", Badge.ToString(), Cognome, Nome);
            }
        }

        class Dipendente : Persona // Prima classe derivata
        {
            public int Matricola { get; set; }
            public int Retribuzione { get; set; }
            new public void StampaInformazioni()
            {
                base.StampaInformazioni();
                Console.WriteLine("Matricola n. {0}, Retribuzione: {1}", Matricola.ToString(), Retribuzione.ToString());
            }  
        }

        class Collaboratore : Persona // Seconda classe derivata
        {
            public string Azienda { get; set; }
            new public void StampaInformazioni()
            {
                base.StampaInformazioni();
                Console.WriteLine("Azienda {0}", Azienda);
            }  
        }

        static void Main(string[] args)
        {
            Persona p = new Persona()
            {
                Badge = 123,
                Cognome = "Da Vinci",
                Nome = "Leonardo"
            };

           Dipendente d = new Dipendente()
            {
                Badge = 456,
                Cognome = "Buonarroti",
                Nome = "Michelangelo",
                Matricola = 123,
                Retribuzione = 1000
            };

            Collaboratore c = new Collaboratore()
            {
                Badge = 789,
                Cognome = "Vecellio",
                Nome = "Tiziano",
                Azienda = "ITIS Viola"
            };

            p.StampaInformazioni();
            d.StampaInformazioni();
            c.StampaInformazioni();
        }
    }
}
    
