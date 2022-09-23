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
        protected double totaleAnnuale;
        protected double totalePrimoAnno;
        protected double totaleTriennale;

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

        public void TotalePrimoAnno(double spesa)
        {
            this.totalePrimoAnno = this.totaleAnnuale + spesa;
        }

        public void TotaleAnnuale()
        {
            this.totaleAnnuale = this.materia + this.oneri + this.contatore + this.spesaFissa;
        }

        public void TotaleTriennale()
        {
            this.totaleTriennale = this.totalePrimoAnno + 2 * this.totaleAnnuale;
        }

        public double GetTotaleTriennale()
        {
            return this.totaleTriennale;
        }

        public string StampaAttuale()
        {
            return $"Bolletta attuale: {this.totaleAnnuale} €/anno\n";
        }

        public override string ToString()
        {
            return $"\nBolletta primo anno: {Math.Round(this.totalePrimoAnno, 2)} €\n" +
                   $"Bolletta annuale: {Math.Round(this.totaleAnnuale, 2)} €\n" +
                   $"Bolletta triennale: {Math.Round(this.totaleTriennale, 2)} €\n";
        }
    }
}