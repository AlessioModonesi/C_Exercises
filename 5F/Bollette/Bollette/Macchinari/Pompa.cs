namespace Bolletta
{
    class Pompa : Macchinari
    {
        public Pompa()
        {
            this.acquistoMacchinario = 3000;
            this.installazioneMacchinario = 250;
            this.rendimentoMacchinario = 3.6;
            this.tipoConsumo = "luce";
        }

        public override void UtilizzoAnnuale(double consumo)
        {
            this.utilizzoAnnuale = consumo * (this.potereCalorifico / this.rendimentoMacchinario);
        }

        public override string ToString()
        {
            return "pompa di calore";
        }
    }
}