using System;

namespace OverRiding
{
    class OverRiding
    {
        public class Automobile
        {
            public string marca;
            public string modello;
            public float valore;
            public Automobile(string marca, string modello, float valore)
            {
                this.marca = marca;
                this.modello = modello;
                this.valore = valore;
            }
            public virtual float costo()
            {
                return valore + 10;
            }
        }

        class Utilitaria : Automobile
        {
            private string alimentazione;
            private string dotazioni;
            public Utilitaria(string marca, string modello, float valore, string alimentazione, string dotazioni) : base(marca, modello, valore)
            {
                this.alimentazione = alimentazione;
                this.dotazioni = dotazioni;
            }
            public override float costo()
            {
                return valore + 300;
            }
        }

        class Berlina : Automobile
        {
            private string alimentazione;
            private string dotazioni;
            public Berlina(string marca, string modello, float valore, string alimentazione, string dotazioni) : base(marca, modello, valore)
            {
                this.alimentazione = alimentazione;
                this.dotazioni = dotazioni;
            }
            public override float costo()
            {
                return valore + 5500;
            }
        }

        static void Main(string[] args)
        {
            Utilitaria MiaAutomobile = new Utilitaria("Fiat", "500", 7500, "GPL", "Base");
            Berlina TuaAutomobile = new Berlina("BMW", "M5", 75000, "Diesel", "Luxury");

            float costo1 = MiaAutomobile.costo();
            string marca1 = MiaAutomobile.marca;
            string modello1 = MiaAutomobile.modello;
            Console.WriteLine(marca1 + " " + modello1 + " - Costo: " + costo1);

            float costo2 = TuaAutomobile.costo();
            string marca2 = TuaAutomobile.marca;
            string modello2 = TuaAutomobile.modello;
            Console.WriteLine(marca2 + " " + modello2 + " - Costo: " + costo2);
        }
    }
}