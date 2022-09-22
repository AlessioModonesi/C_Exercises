namespace Bolletta
{
    class Macchinari
    {
        //attributi da settare
        public double pt; // il potere calorifico (PT) di 1 Smc di gas metano è di circa 10,7 KWh.
        protected double consumo; // consumo familiare gas e luce
        protected int acquisto; // costo di acquisto del macchinario
        protected int installazione; // costo di installazione del macchinario
        protected double rendimento; // rendimento del macchinario 
        protected double costoMateria; // costo Smc o KWh
        protected string tipoConsumo; // tipo di consumo gas/luce
        //attributi da calcolare
        protected double utilizzo; // da calcolare con il consumo, il pt (10,7) e il rendimento
        protected double totale; // totale annuale

        public Macchinari()
        {
            this.pt = 10.7;
            this.tipoConsumo = "";
        }

        public virtual void Utilizzo(double consumo) { }

        public void TotaleAnnuale()
        {
            this.totale = this.costoMateria * (this.consumo + this.utilizzo);
        }

        public void SetConsumo(double consumo)
        {
            this.consumo = consumo;
        }
        public string GetTipoConsumo()
        {
            return this.tipoConsumo;
        }

        public override string ToString()
        {
            return $"Utilizzo: {Math.Round(this.utilizzo, 2)}";
        }
    }
}