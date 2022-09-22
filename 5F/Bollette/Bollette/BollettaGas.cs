namespace Bolletta
{
    class BollettaGas
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int qvd;

        //attributi da calcolare
        protected double gas;
        protected double totale;

        public BollettaGas()
        {
            this.gas = 0;
            this.oneri = 47;
            this.contatore = 96;
            this.qvd = 70;
        }

        public void TotaleBollettaGas()
        {
            this.totale = this.gas + this.oneri + this.contatore + this.qvd;
        }

        public override string ToString()
        {
            return "\nRiepilogo bolletta gas:\n" +
                   $"Gas: {Math.Round(this.gas, 2)}\n" +
                   $"Oneri: {this.oneri} €\n" +
                   $"Contatore: {this.contatore}\n" +
                   $"QVD: {this.qvd}\n" +
                   $"Totale: {Math.Round(this.totale, 2)} €\n";
        }
    }
}