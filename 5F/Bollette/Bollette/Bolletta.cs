namespace Bolletta
{
    class Bolletta
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int spesaFissa; //qvd o pcv

        //attributi da calcolare
        protected double materia;
        protected double spesaIniziale;
        protected double totaleAnnuale;

        public Bolletta()
        {
            this.oneri = 47;
            this.contatore = 96;
            this.spesaFissa = 70;
        }

        public void SetMateria(double materia)
        {
            this.materia = materia;
        }

        public void SetSpesaIniziale(double spesaIniziale)
        {
            this.spesaIniziale = spesaIniziale;
        }

        public void TotaleAnnuale()
        {
            this.totaleAnnuale = this.materia + this.oneri + this.contatore + this.spesaFissa;
        }

        public double GetTotaleAnnuale()
        {
            return this.totaleAnnuale;
        }

        public string StampaAttuale()
        {
            return $"\nBolletta: {Math.Round(this.totaleAnnuale, 2)} €/anno\n";
        }

        public override string ToString()
        {
            return $"Spese iniziali: {Math.Round(this.spesaIniziale, 2)} €\n" +
                   $"Bolletta: {Math.Round(this.totaleAnnuale, 2)} €/anno\n";
        }
    }
}