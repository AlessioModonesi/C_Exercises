namespace Bolletta
{
    class BollettaLuce
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int pcv;

        //attributi da calcolare
        protected double luce;
        protected double totale;

        public BollettaLuce()
        {
            this.luce = 0;
            this.oneri = 47;
            this.contatore = 96;
            this.pcv = 70;
        }

        public void TotaleBollettaLuce()
        {
            this.totale = this.luce + this.oneri + this.contatore + this.pcv;
        }

        public override string ToString()
        {
            return "\nRiepilogo bolletta luce:\n" +
                   $"Luce: {Math.Round(this.luce, 2)}\n" +
                   $"Oneri: {this.oneri} €\n" +
                   $"Contatore: {this.contatore}\n" +
                   $"PCV: {this.pcv}\n" +
                   $"Totale: {Math.Round(this.totale, 2)} €\n";
        }
    }
}