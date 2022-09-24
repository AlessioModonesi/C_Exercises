namespace Bolletta
{
    class Bolletta
    {
        //attributi da settare
        protected int oneri;
        protected int contatore;
        protected int spesaFissa; //qvd o pcv

        //attributi da calcolare/ricavare
        private string macchinario;
        protected double materia;
        protected double totaleAnnuale;
        protected double decennale;

        public Bolletta()
        {
            this.oneri = 47;
            this.contatore = 96;
            this.spesaFissa = 70;
            this.macchinario = "";
        }

        public void SetMateria(double materia)
        {
            this.materia = materia;
        }

        public double GetMateria()
        {
            return this.materia;
        }

        public void SetMacchinario(string macchinario)
        {
            this.macchinario = macchinario;
        }

        public string GetMacchinario()
        {
            return this.macchinario;
        }

        public void TotaleAnnuale()
        {
            this.totaleAnnuale = this.materia + this.oneri + this.contatore + this.spesaFissa;
        }

        public double GetTotaleAnnuale()
        {
            return this.totaleAnnuale;
        }

        public void Decennale()
        {
            this.decennale = (10 * this.totaleAnnuale);
        }

        public double GetDecennale()
        {
            return this.decennale;
        }

        public override bool Equals(object obj)
        {
            if (!this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Bolletta b = (Bolletta)obj;
                if (this.GetTotaleAnnuale() == b.GetTotaleAnnuale() &&
                    this.GetDecennale() == b.GetDecennale())
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Bolletta: {Math.Round(this.totaleAnnuale, 2)} €/anno\n" +
                   $"Decennale: {Math.Round(this.decennale, 2)} €\n";
        }
    }
}