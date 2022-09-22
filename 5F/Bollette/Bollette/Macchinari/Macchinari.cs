namespace Bolletta
{
    class Macchinari
    {
        //attributi da settare
        public double potereCalorifico; // il potere calorifico (PT) di 1 Smc di gas metano è di circa 10,7 KWh.
        protected double acquistoMacchinario; // costo di acquisto del macchinario
        protected double installazioneMacchinario; // costo di installazione del macchinario
        protected double rendimentoMacchinario; // rendimento del macchinario 
        protected string tipoConsumo; // tipo di consumo gas/luce
        protected double costoMateria; // costo gas/luce
        protected double consumoAnnuale; // consumo familiare gas e luce

        //attributi da calcolare
        protected double utilizzoAnnuale; // da calcolare con il consumo, il pt (10,7) e il rendimento
        protected double totaleAnnuale; // totale annuale

        public Macchinari()
        {
            this.potereCalorifico = 10.7;
            this.tipoConsumo = "";
        }

        public string GetTipoConsumo()
        {
            return this.tipoConsumo;
        }

        public void SetConsumoAnnuale(double consumo)
        {
            this.consumoAnnuale = consumo;
        }

        public virtual void UtilizzoAnnuale(double consumo) { }

        public void TotaleAnnuale()
        {
            this.totaleAnnuale = this.costoMateria * (this.consumoAnnuale + this.utilizzoAnnuale);
        }

        public override string ToString()
        {
            return "\nRiepilogo macchinario:\n" +
                   $"Acquisto: {Math.Round(this.acquistoMacchinario, 2)} €\n" +
                   $"Installazione: {Math.Round(this.installazioneMacchinario, 2)} €\n" +
                   $"Rendimento: {Math.Round(this.rendimentoMacchinario, 2)}\n" +
                   $"Tipo consumo: {this.tipoConsumo}\n" +
                   $"Utilizzo annuale: {Math.Round(this.utilizzoAnnuale, 2)}\n" +
                   $"Totale: {Math.Round(this.totaleAnnuale, 2)} €\n";

        }
    }
}