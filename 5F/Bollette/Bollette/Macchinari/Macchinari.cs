namespace Bolletta
{
    class Macchinari
    {
        //attributi da settare
        public double pt; // il potere calorifico (PT) di 1 Smc di gas metano è di circa 10,7 KWh.
        protected double consumo { get; set; } // consumo familiare gas e luce
        protected int acquisto { get; set; } // costo di acquisto del macchinario
        protected int installazione { get; set; } // costo di installazione del macchinario
        protected double rendimento { get; set; } // rendimento del macchinario 
        protected double costoMateria { get; set; } // costo Smc o KWh
        protected string tipoConsumo { get; set; } // tipo di consumo gas/luce
        //attributi da calcolare
        protected double utilizzo { get; set; } // da calcolare con il consumo, il pt (10,7) e il rendimento
        protected double totale { get; set; } // totale annuale

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

        public override string ToString()
        {
            return $"Rendimento: {this.rendimento} \nCosto {this.tipoConsumo}: {this.costoMateria} € \nConsumo: {this.consumo}";
        }
    }
}