namespace Bolletta
{
    class Bolletta
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int spesaFissa; //qvd o pcv

        //attributi da calcolare
        protected double materia; //da ricavare da altre classi
        protected double totalePrimoAnno;
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

        public void TotalePrimoAnno(double spesa)
        {
            this.totalePrimoAnno = this.totaleAnnuale + spesa;
        }

        public void TotaleBolletta()
        {
            this.totaleAnnuale = this.materia + this.oneri + this.contatore + this.spesaFissa;
        }

        public double GetPrimoAnno()
        {
            return this.totalePrimoAnno;
        }

        public double GetAnniSuccessivi()
        {
            return this.totaleAnnuale;
        }

        public override string ToString()
        {
            return $"\nBolletta 1o anno: {Math.Round(this.totalePrimoAnno, 2)} €\n" +
                   $"Bollette successive: {Math.Round(this.totaleAnnuale, 2)} €\n";
        }
    }
}