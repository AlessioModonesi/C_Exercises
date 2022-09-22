namespace Bolletta
{
    class PompaEco : Macchinari
    {
        public PompaEco()
        {
            this.acquistoMacchinario = 1000;
            this.installazioneMacchinario = 250;
            this.rendimentoMacchinario = 2.8;
            this.tipoConsumo = "luce";
            this.costoMateria = 0.28;
        }

        public override void UtilizzoAnnuale(double consumo)
        {
            this.utilizzoAnnuale = consumo * (this.potereCalorifico / this.rendimentoMacchinario);
        }
    }
}