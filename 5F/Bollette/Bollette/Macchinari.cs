namespace Bolletta
{
    class Macchinari
    {
        //attributi da settare
        protected double consumo { get; set; } // consumo familiare gas e luce
        protected int acquisto { get; set; } // costo di acquisto del macchinario
        protected int installazione { get; set; } // costo di installazione del macchinario
        protected double rendimento { get; set; } // rendimento del macchinario 
        protected double costoMateria { get; set; } // costo Smc o KWh
        protected string tipoConsumo { get; set; } // tipo di consumo gas/luce
        //attributi da calcolare
        protected double utilizzo { get; set; } // da calcolare con il consumo, il pt (10,7) e il rendimento
        protected double totale { get; set; } // totale annuale

        public Macchinari() { }

        public virtual void Utilizzo(double consumo) { }

        public void TotaleAnnuale()
        {
            this.totale = this.costoMateria * (this.consumo + this.utilizzo);
        }

        public override string ToString()
        {
            return $"Rendimento: {this.rendimento}, costo materia: {this.costoMateria} e consumo: {this.consumo}";
        }
    }
}