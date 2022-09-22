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
        protected double costoGas; // costo gas
        protected double costoLuce; // costo luce
        protected double consumoAnnuale; // consumo familiare gas e luce

        //attributi da calcolare
        protected double costoMateria; // costo materia gas/luce
        protected double utilizzoAnnuale; // da calcolare con il consumo, il pt (10,7) e il rendimento
        protected double totale; // totale annuale

        public Macchinari()
        {
            this.potereCalorifico = 10.7;
            this.costoGas = 1.05;
            this.costoLuce = 0.276;
            this.tipoConsumo = "";
        }

        public string GetTipoConsumo() //prendo il tipo di consumo dell'impianto
        {
            return this.tipoConsumo;
        }

        //inizio calcolo totale
        public void SetCostoGas() //setto il costo di gas e luce
        {
            this.costoMateria = this.costoGas;
        }

        public void SetCostoLuce() //setto il costo di gas e luce
        {
            this.costoMateria = this.costoLuce;
        }

        public void SetConsumoAnnuale(double consumo) //setto il consumo annuale di (gas/luce)
        {
            this.consumoAnnuale = consumo;
        }

        public virtual void UtilizzoAnnuale(double consumo) { } //calcolo l'utilizzoAnnuale

        public double Totale() //calcolo il totale
        {
            return this.totale = this.costoMateria * (this.consumoAnnuale + this.utilizzoAnnuale);
        }
        //fine calcolo totale

        public double GetAcquistoInstallazione() //prendo la somma di acquisto e installazione
        {
            return this.acquistoMacchinario + this.installazioneMacchinario;
        }

        public override string ToString()
        {
            return $"Acquisto: {Math.Round(this.acquistoMacchinario, 2)} €\n" +
                   $"Installazione: {Math.Round(this.installazioneMacchinario, 2)} €\n" +
                   $"Utilizzo annuale: {Math.Round(this.utilizzoAnnuale, 2)}\n" +
                   $"Totale: {Math.Round(this.totale, 2)} €";
        }
    }
}