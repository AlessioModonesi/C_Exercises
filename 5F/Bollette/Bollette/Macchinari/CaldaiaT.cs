namespace Bolletta
{
    class CaldaiaT : Macchinari
    {
        public CaldaiaT()
        {
            this.acquistoMacchinario = 1500;
            this.installazioneMacchinario = 300;
            this.rendimentoMacchinario = 0.9;
            this.tipoConsumo = "gas";
            this.costoMateria = 1.05;
        }

        public override void UtilizzoAnnuale(double consumo)
        {
            this.utilizzoAnnuale = consumo / (this.potereCalorifico * this.rendimentoMacchinario);
        }
    }
}