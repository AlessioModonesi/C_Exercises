namespace Bolletta
{
    class Bolletta
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int qvd;

        //attributi da calcolare
        protected double gas;
        protected double totale;

        public Bolletta()
        {
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
            return $"Bolletta: {Math.Round(this.totale, 2)} €";
        }
    }
}