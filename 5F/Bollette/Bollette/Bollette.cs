namespace Bolletta
{
    class Bolletta
    {
        //attributi da settare
        public double pt; // il potere calorifico (PT) di 1 Smc di gas metano è di circa 10,7 KWh.
        protected double gas { get; set; }
        protected int oneri;
        protected int contatore;
        protected int qvd;
        //attributi da calcolare
        protected double totale { get; set; }

        public Bolletta()
        {
            this.pt = 10.7;
            this.gas = 0;
            this.oneri = 47;
            this.contatore = 96;
            this.qvd = 70;
        }

        public void TotaleBolletta()
        {
            this.totale = this.gas + this.oneri + this.contatore + this.qvd;
        }

        public override string ToString()
        {
            return $"Costo bolletta: {Math.Round(this.totale, 4)}€";
        }
    }
}